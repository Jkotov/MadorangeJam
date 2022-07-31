using System;
using UnityEngine;
[RequireComponent(typeof(TeamComponent))]
public class HealthComponent : MonoBehaviour
{
    public GameObject objectForDestroy;
    [HideInInspector] public TeamComponent teamComponent;

    private void Awake()
    {
        teamComponent = GetComponent<TeamComponent>();
    }

    public float Health
    {
        get => health;
        set
        {
            health = value;
            if (health <= 0)
                Die();
        }
    }

    public float health;
    public void Die()
    {
        if (TryGetComponent(out SpawnToTarget spawnToTarget))
            spawnToTarget.Spawn();
        if (objectForDestroy != null)
            Destroy(objectForDestroy);
        Destroy(gameObject);
    }
}
