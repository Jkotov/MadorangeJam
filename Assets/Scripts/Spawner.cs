using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject unitPrefab;
    public AttackButton attackButton;
    public void Spawn(Vector3 unitTarget)
    {
        var move = Instantiate(unitPrefab, transform.position, Quaternion.identity).GetComponent<MoveComponent>();
        move.agent.SetDestination(unitTarget);
        if (attackButton != null)
        {
            attackButton.moveComponents.Add(move);
        }
    }
}
