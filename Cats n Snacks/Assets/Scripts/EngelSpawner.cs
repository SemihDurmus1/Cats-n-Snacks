using Platformer;
using UnityEngine;

public class EngelSpawner : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] GameObject engelPrefab; //Buraya sonradan farklý engeller eklenecek

    [SerializeField] float maxY = 4f;
    [SerializeField] float minY = -2.75f;

    [SerializeField] float timeBetweenSpawn = 1f;
    private float spawnTime;

    float randomY;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

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
        randomY = Random.Range(minY, maxY);

        Instantiate(engelPrefab, transform.position + new Vector3(transform.position.x, randomY, 0), transform.rotation);

        SpawnHiziDegistir();
    }

    private void SpawnHiziDegistir()
    {
        //Bu methodu, engeller hýzlanýnca arada çok boþluk oluyordu, onu engellemek için yaptým
        if (gameManager.skor > 1500)
        {
            timeBetweenSpawn = Random.Range(0.5f, 1.0f);
        }
        else
        {
            timeBetweenSpawn = Random.Range(0.5f, 2.0f);
        }
    }
}
