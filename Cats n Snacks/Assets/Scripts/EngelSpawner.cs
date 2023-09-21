using UnityEngine;

public class EngelSpawner : MonoBehaviour
{
    [SerializeField] GameObject engeller; //Buraya sonradan farklý engeller eklenecek

    [SerializeField] float maxX = 4;
    [SerializeField] float minX = 4;

    [SerializeField] float maxY = 4;
    [SerializeField] float minY = 4;

    [SerializeField] float timeBetweenSpawn = 1f;
    private float spawnTime;

    float randomX;
    float randomY;

    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);

        Instantiate(engeller, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
