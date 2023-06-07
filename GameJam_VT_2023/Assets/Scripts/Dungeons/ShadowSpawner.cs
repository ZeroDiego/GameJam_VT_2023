using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject shadow;

    private float spawnInterval = 10f;

    [SerializeField] List<GameObject> shadows;

    void Start()
    {
        StartCoroutine(SpawnShadow(spawnInterval, shadow));
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnShadow(float time, GameObject shadowToSpawn)
    {
        yield return new WaitForSeconds(time);

        GameObject newShadow = Instantiate(shadowToSpawn, new Vector3(Random.Range(2, 6), Random.Range(2, 16), 0), Quaternion.identity);
        shadows.Add(newShadow);
        if (shadows.Count < 6)
        {
            StartCoroutine(SpawnShadow(spawnInterval, shadow));
        }
    }

    public void RemoveShadow(GameObject shadowToRemove)
    {
        if (shadows.Contains(shadowToRemove))
        {
            if (shadows.Count == 6)
            {
                StartCoroutine(SpawnShadow(spawnInterval, shadow));
            }    
            shadows.Remove(shadowToRemove);
        }
    }
}
