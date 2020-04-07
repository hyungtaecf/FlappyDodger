using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;

    public GameObject blockPrefab;

    public float timeBetweenWaves = 1f;

    private float timeToSpawn = 2f;

    private float blockRandomForce = 10;

    private float blockSpinRange = 5;
    
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
            blockRandomForce+=2;
            blockSpinRange++;
        }

    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Rigidbody2D block = Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity)
                    .GetComponent<Rigidbody2D>();
                float randomXForce = Random.Range(-blockRandomForce, blockRandomForce);
                float randomYForce = Random.Range(-blockRandomForce, blockRandomForce);
                float randomSpin = Random.Range(-blockSpinRange, blockSpinRange);
                block.AddForce(new Vector2(randomXForce, randomYForce));
                block.AddTorque(randomSpin);
            }
        }
    }
}
