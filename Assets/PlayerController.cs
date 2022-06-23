using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Vector2 movementDirection;
    public InputAction movement;
    public InputAction fire;
    public Rigidbody2D rb;
    public float health = 3;
    public Rigidbody2D projectile;
    private GameObject gameManager;

    public Text healthCount;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnEnable()
    {
        fire.Enable();
        movement.Enable();
    }

    private void OnDisable()
    {
        fire.Disable();
        movement.Disable();
    }

    private void Fire(Rigidbody2D projectile)
    {
        Rigidbody2D bullet = Instantiate(projectile, transform.position,transform.rotation) as Rigidbody2D;
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f);
    }

    void TakeDamage(int amount = 1)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameManager.GetComponent<UIScript>().SetLose();
        gameManager.GetComponent<UIScript>().LoadNextLevel();
        this.gameObject.SetActive(false);
        
    }

    private void Update()
    {
        healthCount.text = health.ToString();
        if (fire.triggered)
        {
            Fire(projectile);
        }
        movementDirection = movement.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Die();
            Destroy(collision.gameObject);
        }
        //TakeDamage();
    }
 
   

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementDirection.x * movementSpeed, 0);
    }

}
