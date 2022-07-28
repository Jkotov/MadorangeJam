using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveComponent : MonoBehaviour
{
  //  public Transform target;
    [HideInInspector] public NavMeshAgent agent;

  /*  [ContextMenu("Run")]
    public void Run()
    {
        agent.SetDestination(target.position);
    }*/
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}