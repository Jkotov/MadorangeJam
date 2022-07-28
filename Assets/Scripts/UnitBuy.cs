using System;
using UnityEngine;

public class UnitBuy : MonoBehaviour
{
    public LayerMask raycastTarget;
    public Spawner spawner;
    public int moneyForSpawn;
    public Camera cameraMain;
    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (MoneyManager.Instance.TrySpend(moneyForSpawn))
            {
                var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, raycastTarget);
                spawner.Spawn(hitInfo.point);
            }
        }
    }
}
