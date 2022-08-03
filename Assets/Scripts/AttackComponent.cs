using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TeamComponent))]
public class AttackComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float attackCooldown;
    public List<string> targetTagPriority;
    private float lastAttackTime;
    protected TeamComponent teamComponent;
    private readonly Dictionary<string, List<Collider>> enemies = new Dictionary<string, List<Collider>>();

    protected virtual void Awake()
    {
        foreach (var targetTag in targetTagPriority)
        {
            enemies.Add(targetTag, new List<Collider>());
        }
        teamComponent = GetComponent<TeamComponent>();
    }
    private void Update()
    {
        for (int i = 0; i < targetTagPriority.Count; i++)
        {
            foreach (var enemy in enemies[targetTagPriority[i]])
            {
                if (enemy == null)
                    continue;
                lastAttackTime = Time.time;
                Attack(enemy.transform);
                goto Attacked;
            }
        } 
        Attacked:
        foreach (var enemyPair in enemies)
        {
            enemyPair.Value.Clear();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent(out HealthComponent health))
            return;
        if (other.GetComponent<TeamComponent>().team == teamComponent.team)
            return;
        if (!(Time.time - lastAttackTime >= attackCooldown)) return;
        if (!targetTagPriority.Contains(other.tag))
            return;
        enemies[other.tag].Add(other);
    }

    public virtual void Attack(Transform target)
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Target = target;
        bullet.teamComponent.team = teamComponent.team;
    }
}