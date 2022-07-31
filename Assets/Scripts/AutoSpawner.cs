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
    public List<Transform> patrolPath = new List<Transform>();
    public float patrolIdleTime;
    public Transform onDeathTarget;
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
            var obj = spawner.Spawn(target.position);
            if (patrolPath.Count > 0)
            {
                var patrolComponent = obj.AddComponent<PatrolComponent>();
                patrolComponent.wps = patrolPath;
                patrolComponent.patrolIdleTime = patrolIdleTime;
            }
            if (onDeathTarget != null && obj.TryGetComponent(out SpawnToTarget spawnerOnDeath))
                spawnerOnDeath.target = onDeathTarget;
        }
    }
}
