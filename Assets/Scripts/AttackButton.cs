using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public Transform attackTarget;
    public List<MoveComponent> moveComponents;

    public void Attack()
    {
        int i = 0;
        while (i < moveComponents.Count)
        {
            if (moveComponents[i] == null)
                moveComponents.Remove(moveComponents[i]);
            else
                i++;
        }
        foreach (var moveComponent in moveComponents)
        {
            if (moveComponent == null)
                moveComponents.Remove(moveComponent);
            else
                moveComponent.agent.SetDestination(attackTarget.position);
        }
    }
}