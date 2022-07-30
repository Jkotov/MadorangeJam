using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackButton : MonoBehaviour
{
    public Transform attackTarget;
    public List<NavMeshAgent> agents;

    public void Attack()
    {
        int i = 0;
        while (i < agents.Count)
        {
            if (agents[i] == null)
                agents.Remove(agents[i]);
            else
                i++;
        }
        foreach (var moveComponent in agents)
        {
            if (moveComponent == null)
                agents.Remove(moveComponent);
            else
                moveComponent.SetDestination(attackTarget.position);
        }
    }
}