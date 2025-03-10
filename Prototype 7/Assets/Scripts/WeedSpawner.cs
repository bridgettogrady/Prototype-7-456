using UnityEngine;

public class WeedSpawner : MonoBehaviour
{
    public GameObject weedPrefab;
    public int maxWeeds = 20;
    public float spawnYPos;

    private int currentWeeds = 0;
    private int seedAmount = 0;
    private float spawnTimer = 0f;
    public float invokeInteval = 1f;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnWeed();
            spawnTimer = invokeInteval * (((float)maxWeeds - (float)seedAmount) / (float)maxWeeds);
        }
    }

    void SpawnWeed()
    {
        if (currentWeeds >= maxWeeds) return;
        float spawnXPos = Random.Range(-8.8f, 8.6f);
        Vector2 spawnPos = new Vector2(spawnXPos, spawnYPos);

        Instantiate(weedPrefab, spawnPos, Quaternion.identity);
        currentWeeds++;
    }

    public void WeedRemoved()
    {
        currentWeeds--;
    }

    public void UpdateSeedCount(bool isSeedVisible)
    {
        if (isSeedVisible)
        {
            seedAmount++;
            spawnTimer += 0.3f;
        }
        else
        {
            seedAmount--;
        }
    }
}
