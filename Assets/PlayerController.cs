using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Vector2 movementDirection;
    public InputAction movement;
    public InputAction fire;
    public Rigidbody2D rb;
    public float health = 3;
    public Rigidbody2D projectile;


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

    private void Update()
    {
        if (fire.triggered)
        {
            Fire(projectile);
        }
        movementDirection = movement.ReadValue<Vector2>();
    }

    

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementDirection.x * movementSpeed, 0);
    }

}
