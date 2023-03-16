using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject zombie;
    public float minSpawnTime = 1000000f;
    public float maxSpawnTime = 1500000f;
    private float lastSpawnTime = 0f;
    private float spawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Auto set up Spawn Ponit into Array GameObject[] spawnPoint
        spawnPoint = GameObject.FindGameObjectsWithTag("Respawn");
        UpdateSpawnTime();
    }

    void UpdateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Spawn()
    {
        //Spawn in Auto Random Point
        int point = Random.Range(0, spawnPoint.Length - 1);
        //Quaternion.identity is no rotation
        Instantiate(zombie, spawnPoint[point].transform.position, Quaternion.identity);
        UpdateSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= lastSpawnTime + spawnTime)
        {
            Spawn();
        }
    }
}
