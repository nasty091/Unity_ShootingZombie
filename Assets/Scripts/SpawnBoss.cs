using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject Boss;
    private GameObject bossSpawnPoint;
    private bool roundTwo;

    private void Start()
    {
        bossSpawnPoint = GameObject.FindGameObjectWithTag("RespawnBoss");
       
    }

    private void Update()
    {
        for (int i = 0; i < 1; i++)
        {
            UpdateSpawn();
        }
    }

    private void UpdateSpawn()
    {
        if (roundTwo)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(Boss, gameObject.transform.position, Quaternion.identity);
    }
}
