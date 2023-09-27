using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spritePrefab;

    [SerializeField] float maxX = 4f;
    [SerializeField] float minX = 4f;

    [SerializeField] float maxY = 4f;
    [SerializeField] float minY = 1.5f;

    [SerializeField] float timeBetweenSpawn = 10f;
    private float spawnTime;

    float randomX;
    float randomY;

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);

        Instantiate(spritePrefab[Random.Range(0, spritePrefab.Length)], 
                                 transform.position + 
                                 new Vector3(randomX, randomY, 0),
                                 transform.rotation);

        timeBetweenSpawn = Random.Range(10f, 15f);
    }

}
