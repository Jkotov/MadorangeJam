using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPaddles : MonoBehaviour
{
    public GameObject brash;
    public Animator animator;
    public NavMeshAgent agent;
    private readonly List<Transform> paddles = new List<Transform>();
    private Transform currentPaddle;
    private static readonly int IsWorking = Animator.StringToHash("IsWorking");

    private void Update()
    {
        if (currentPaddle != null)
            return;
        brash.SetActive(false);
        animator.SetBool(IsWorking, false);
        paddles.RemoveAll(p => p == null);

        foreach (var paddle in paddles)
        {
            if (currentPaddle == null)
                currentPaddle = paddle;
            if ((currentPaddle.position - transform.position).sqrMagnitude >
                (paddle.position - transform.position).sqrMagnitude)
                currentPaddle = paddle;
        }
        if (currentPaddle != null)
            agent.SetDestination(currentPaddle.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Paddle paddle))
            paddles.Add(paddle.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Paddle paddle))
            paddles.Remove(paddle.transform);
    }
}
