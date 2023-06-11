using UnityEngine;
using System.Collections;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnXLimit = 6f;

    public GameObject redMeteorPrefab;
    public float minSpawnDelayForRed = 5f;
    public float maxSpawnDelayForRed = 10f;

    public GameObject greenMeteorPrefab;
    public float minSpawnDelayForGreen = 3f;
    public float maxSpawnDelayForGreen = 5f;

    float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        SpawnRed();
        SpawnGreen();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    void Spawn()
    {
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));

        if (minSpawnDelay > 0.1f)
        {
            minSpawnDelay -= elapsedTime / 1000f;
            maxSpawnDelay -= elapsedTime / 1000f;
        }
    }

    void SpawnRed()
    {
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(redMeteorPrefab, spawnPos, Quaternion.identity);

        Invoke("SpawnRed", Random.Range(minSpawnDelayForRed, maxSpawnDelayForRed));

        if (minSpawnDelayForRed > 3f)
        {
            minSpawnDelayForRed -= elapsedTime / 1000f;
            maxSpawnDelayForRed -= elapsedTime / 1000f;
        }
    }

    void SpawnGreen()
    {
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(greenMeteorPrefab, spawnPos, Quaternion.identity);

        Invoke("SpawnGreen", Random.Range(minSpawnDelayForGreen, maxSpawnDelayForGreen));

        if (minSpawnDelayForGreen > 1f)
        {
            minSpawnDelayForGreen -= elapsedTime / 1000f;
            maxSpawnDelayForGreen -= elapsedTime / 1000f;
        }
    }
}
