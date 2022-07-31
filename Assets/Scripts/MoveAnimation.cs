using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private bool IsMove
    {
        get => isMove;
        set
        {
            if (isMove != value)
            {
                animator.SetBool(IsMoving, value);
            }
            isMove = value;
        }
    }

    private bool isMove;

    private void Update()
    { 
        IsMove = agent.stoppingDistance < agent.remainingDistance;
    }
}
