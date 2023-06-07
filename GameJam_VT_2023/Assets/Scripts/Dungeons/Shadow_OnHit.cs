using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow_OnHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            Debug.Log("Start battle!");
        }
    }
}
