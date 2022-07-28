using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class AutoSpawner : MonoBehaviour
{
    public float spawnCooldown;
    public float lastSpawnTime;
    public Transform target;
    private Spawner spawner;
    
    private void Awake()
    {
        spawner = GetComponent<Spawner>();
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime >= spawnCooldown)
        {
            lastSpawnTime = Time.time;
            spawner.Spawn(target.position);
        }
    }
}
