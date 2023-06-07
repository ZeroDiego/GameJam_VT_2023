using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Dungeon : MonoBehaviour
{
    public List<GameObject> objectsToActivate;

    private void Start()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }
    }
}
