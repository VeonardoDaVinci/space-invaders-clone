using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyBehaviour : MonoBehaviour
{
    private Vector2[] movementPattern = { Vector2.left, Vector2.left, Vector2.left, Vector2.left, Vector2.left, Vector2.left, Vector2.down, Vector2.down,
                                Vector2.right ,Vector2.right ,Vector2.right, Vector2.right, Vector2.right, Vector2.right, Vector2.down, Vector2.down};
    private int startIndex = 3;
    private int currentIndex;
    private float movementSpeed = 0.3f;
    private int shootChance;
    private float health = 2;


    private GameManager gameManager;
    [SerializeField] private Rigidbody2D damageSource;
    [SerializeField] private Rigidbody2D projectile;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        gameManager = GameManager.Instance;
        currentIndex = startIndex;
        InvokeRepeating("ChangePositon", 1f, 1f);
        InvokeRepeating("Fire", 0.5f, 1f);
        
    }

    void TakeDamage(int amount = 1)
    {
        health -= amount;
        if (health <= 0)
        {
            gameManager.score += 100;
            gameManager.enemyCount--;
            Destroy(this.gameObject);
            
        }
    }


    private void Fire()
    {
        shootChance = Random.Range(1, 10);
        if(shootChance<2)
        {
            Rigidbody2D bullet = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * -200f);
        }
    }

    private void ChangePositon()
    {
        currentIndex %= movementPattern.Length;
        rb.MovePosition(new Vector2(transform.position.x,transform.position.y) + movementPattern[currentIndex] * movementSpeed);
        currentIndex++;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

}
