using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolComponent : MonoBehaviour
{
    public float remainingDistance;
    public List<Transform> wps;
    public float patrolIdleTime;
    private float startIdleTime;
    private int currentWp;
    private NavMeshAgent agent;
    private bool idling;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!(agent.remainingDistance <= remainingDistance)) return;
        
        if (Time.time > startIdleTime && !idling)
        {
            idling = true;
            startIdleTime = Time.time;
        }
        if (Time.time > startIdleTime + patrolIdleTime)
        {
            agent.SetDestination(wps[currentWp % (wps.Count - 1)].position);
            currentWp++;
            idling = false;
        }
    }
}
