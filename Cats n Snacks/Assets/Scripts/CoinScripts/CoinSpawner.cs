using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject greenFoodPrefab;
    [SerializeField] GameObject blueFoodPrefab;
    [SerializeField] GameObject redFoodPrefab;

    [SerializeField] float maxY = 2f;
    [SerializeField] float minY = -2.75f;

    [SerializeField] float timeBetweenSpawn = 1.5f;
    private float spawnTime;

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
        randomY = Random.Range(minY, maxY);
        float spawnChance = Random.value;

        if (spawnChance < 0.2f) //Mavi veya kýrmýzý mamanýn çýkma olasýlýðý %20
        {
            if (spawnChance < 0.1f)//Kýrmýzý mamanýn çýkma olasýlýðý %10
            {
                Instantiate(redFoodPrefab, transform.position + new Vector3(transform.position.x, randomY, 0), transform.rotation);
            }
            else // Mavi mamanýn çýkma olasýlýðý %10
            {
                Instantiate(blueFoodPrefab, transform.position + new Vector3(transform.position.x, randomY, 0), transform.rotation);
            }
        }
        else // Geriye kalan %80'lik kýsmýnda yeþil mama çýkacak
        {
            Instantiate(greenFoodPrefab, transform.position + new Vector3(transform.position.x, randomY, 0), transform.rotation);
        }
    }
}
