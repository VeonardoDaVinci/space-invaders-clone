using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
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
    private GameManager gameManager;

    

    private void Start()
    {
        gameManager = GameManager.Instance;
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
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f);
        }

        //Rigidbody2D bullet = Instantiate(projectile, transform.position,transform.rotation) as Rigidbody2D;
        //bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f);
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
        this.gameObject.SetActive(false);
        
    }

    private void Update()
    {
        gameManager.healthCount.text = health.ToString();
        if (fire.triggered)
        {
            Fire(projectile);
        }
        movementDirection = movement.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
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
