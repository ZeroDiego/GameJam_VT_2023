using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_Movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed = 3;
    [SerializeField] float speedLimit = 0.7f;
    GameObject sword;
    float horizontalInput;
    float verticalInput;
    [SerializeField] bool isUsingSword;

    [SerializeField] GameObject doorToDestroy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sword = GameObject.Find("Sword");
        sword.SetActive(false);
    }


    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (doorToDestroy != null && Input.GetKeyDown(KeyCode.Space))
        {
            Door_Dungeon door = doorToDestroy.GetComponent<Door_Dungeon>();
            foreach (GameObject obj in door.objectsToActivate)
            {
                obj.SetActive(true);
            }
            Destroy(doorToDestroy);
            return;
        }

        if (horizontalInput < 0)
        {
            if (verticalInput < 0)
                transform.rotation = Quaternion.Euler(0, 0, 135);
            else if (verticalInput == 0)
                transform.rotation = Quaternion.Euler(0, 0, 90);
            else if (verticalInput > 0)
                transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (horizontalInput == 0)
        {
            if (verticalInput < 0)
                transform.rotation = Quaternion.Euler(0, 0, 180);
            else if (verticalInput > 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput > 0)
        {
            if (verticalInput < 0)
                transform.rotation = Quaternion.Euler(0, 0, 225);
            else if (verticalInput == 0)
                transform.rotation = Quaternion.Euler(0, 0, 270);
            else if (verticalInput > 0)
                transform.rotation = Quaternion.Euler(0, 0, 315);
        }

        if (Input.GetKeyDown(KeyCode.E) && !isUsingSword)
        {
            StartCoroutine(UseSword(0.5f));
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

    private IEnumerator UseSword(float time)
    {
        sword.SetActive(true);
        isUsingSword = true;
        sword.GetComponent<Animator>().SetBool("IsUsingsword", true);

        yield return new WaitForSeconds(time);

        sword.SetActive(false);
        isUsingSword = false;
        sword.GetComponent<Animator>().SetBool("IsUsingsword", false);
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
