using System;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class SpawnToTarget : MonoBehaviour
{
    public Transform target;

    public void Spawn()
    {
        GetComponent<Spawner>().Spawn(target.position);
    }
}