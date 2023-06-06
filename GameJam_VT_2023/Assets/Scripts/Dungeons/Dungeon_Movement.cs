using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_Movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed = 3;
    [SerializeField] float speedLimit = 0.7f;
    float horizontalInput;
    float verticalInput;

    [SerializeField] GameObject doorToDestroy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (doorToDestroy != null && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(doorToDestroy);
        }
    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (horizontalInput != 0 && verticalInput != 0)
            {
                horizontalInput *= speedLimit;
                verticalInput *= speedLimit;
            }
            rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            doorToDestroy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            doorToDestroy = null;
        }
    }
}
