using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_OnHit : MonoBehaviour
{
    ShadowSpawner spawner;

    private void Start()
    {
        spawner = GameObject.Find("Shadow_Spawner").GetComponent<ShadowSpawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow_Behind"))
        {
            Debug.Log("Start battle with advantage!");
            Destroy(collision.transform.parent.gameObject);
            spawner.RemoveShadow(collision.transform.parent.gameObject);
        }
        else if (collision.CompareTag("Shadow"))
        {
            Debug.Log("Start battle!");
            Destroy(collision.gameObject.transform.parent.gameObject);
            spawner.RemoveShadow(collision.transform.parent.gameObject);
        }
    }
}
