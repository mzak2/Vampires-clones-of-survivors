using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField][Range(0, 1)] float probability;
    [SerializeField] float spawnTimer;
    private Vector3 spawnPos;

    float timer;


    private void Update()
    {
        timer -= Time.deltaTime; //timer countdown based on deltatime
        if (timer < 0f)
        {
            SpawnChest(); //methotd for spawning enemy when timer = 0
            timer = spawnTimer;
        }
    }

    private void SpawnChest()
    {
        Vector3 spawnPos = ChestSpawnPosition();
        GameObject spawnChest = Instantiate(toSpawn, spawnPos, Quaternion.identity);
        
    }

    private Vector3 ChestSpawnPosition()
    {
        spawnPos = new Vector3(Random.Range(-95, 95), Random.Range(-95, 95), 0);
        return spawnPos;
    }

    public void Spawn()
    {
        if (Random.value < probability) 
        {
            SpawnManager.instance.SpawnObject(transform.position, toSpawn);
        }
    }


}
