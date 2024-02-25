using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array of object prefabs
    public float spawnHeight = 1.0f;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            
            GameObject selectedPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            Debug.Log("Selected Fruit: " + selectedPrefab.name);
            SpawnObject(selectedPrefab, mousePosition);
        }
    }

    void SpawnObject(GameObject prefab, Vector3 spawnPosition)
    {
        
        spawnPosition.y = spawnHeight;

        
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
