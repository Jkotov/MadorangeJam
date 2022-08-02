using System;
using UnityEngine;
using UnityEngine.AI;

public class PaddleSlower : MonoBehaviour
{
    public NavMeshAgent agent;
    public float slowFactor;
    private float baseSpeed;

    private void Awake()
    {
        baseSpeed = agent.speed;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Paddle paddle))
            agent.speed = baseSpeed * slowFactor;
    }

    private void OnTriggerExit(Collider other)
    {
        agent.speed = baseSpeed;
    }
}