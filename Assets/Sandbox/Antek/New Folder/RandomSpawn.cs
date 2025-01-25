using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsToSpawn = new List<GameObject>();
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();

    private void Awake()
    {
        for (int a = 0; a <= spawnPoints.Count;)
        {
            var random = Random.Range(0, objectsToSpawn.Count);
            Instantiate(objectsToSpawn[random], spawnPoints[a].position, Quaternion.identity);
            spawnPoints.RemoveAt(a);
        }
    }
}
