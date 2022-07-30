using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject unitPrefab;
    public AttackButton attackButton;

    public GameObject Spawn(Vector3 unitTarget)
    {
        var res = Instantiate(unitPrefab, transform.position, Quaternion.identity);
        var move = res.GetComponent<NavMeshAgent>();
        move.SetDestination(unitTarget);
        if (attackButton != null)
        {
            attackButton.agents.Add(move);
        }
        return res;
    }

}
