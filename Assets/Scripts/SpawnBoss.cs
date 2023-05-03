using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject Boss;
    private GameObject bossSpawnPoint;
    private float startSpawnBossTime;

    [SerializeField]
    private float spawnBossTime = 43.0f;

    private void Start()
    {
        UpdateStartSpawnBossTime();
    }

    private void Update()
    {
        if(Time.time >= startSpawnBossTime + spawnBossTime)
        {
            Spawn();
            spawnBossTime = 20.0f;
        }
    }

    public void UpdateStartSpawnBossTime()
    {
        startSpawnBossTime = Time.time;
    }

    public void Spawn()
    {
        Instantiate(Boss, gameObject.transform.position, Quaternion.identity);
        UpdateStartSpawnBossTime();
    }
}
