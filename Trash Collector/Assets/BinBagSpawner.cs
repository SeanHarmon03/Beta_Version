using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinBagSpawner : MonoBehaviour
{
    public GameObject BinBag;
    public Collider[] roadColliders;
    public int spawnCount = 10;
    public float spawnHeight = 0.7f;

    void Start()
    {
        SpawnBinBags();
    }

    void SpawnBinBags()
    {
        for(int i = 0; i < spawnCount; i++)
        {

            Collider randomCollider = roadColliders[Random.Range(0, roadColliders.Length)];
            Vector3 spawnPosition = getRandomPoint(randomCollider);
            spawnPosition.y += spawnHeight;
            Instantiate( BinBag , spawnPosition , Quaternion.identity);
        }
    }
    Vector3 getRandomPoint (Collider collider)
    {
        Bounds bounds = collider.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        return new Vector3(x, bounds.center.y, z);   
        }
}
    
    

   