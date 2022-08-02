using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitBuy : MonoBehaviour
{
    [Serializable]
    public struct SpawnInfo
    {
        public KeyCode code;
        public Spawner spawner;
        public int moneyForSpawn;
    }
    public LayerMask raycastTarget;
    public List<SpawnInfo> spawners;
    private Spawner spawner;
    private int moneyForSpawn;
    public Camera cameraMain;

    private void Awake()
    {
        spawner = spawners[0].spawner;
        moneyForSpawn = spawners[0].moneyForSpawn;
    }

    private void Update()
    {
        foreach (var spawnInfo in spawners)
        {
            if (Input.GetKeyDown(spawnInfo.code))
            {
                spawner = spawnInfo.spawner;
                moneyForSpawn = spawnInfo.moneyForSpawn;
            }
        }
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
