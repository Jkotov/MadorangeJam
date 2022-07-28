using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    public LayerMask raycastTarget;
    public Camera cameraMain;
    private MoveComponent moveComponent;

    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, raycastTarget);
            moveComponent.agent.SetDestination(hitInfo.point);
        }
    }
}
