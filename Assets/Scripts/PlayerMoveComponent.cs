using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveComponent : MonoBehaviour
{
    public LayerMask raycastTarget;
    public Camera cameraMain;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, raycastTarget);
            agent.SetDestination(hitInfo.point);
        }
    }
}
