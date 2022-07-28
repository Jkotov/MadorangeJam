using System;
using UnityEngine;

[RequireComponent(typeof(TeamComponent))]
public class AttackComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float attackCooldown;
    private float lastAttackTime;
    private TeamComponent teamComponent;

    private void Awake()
    {
        teamComponent = GetComponent<TeamComponent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent(out HealthComponent health))
            return;
        if (other.GetComponent<TeamComponent>().team == teamComponent.team)
            return;
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            Attack(other.transform);
        }
    }

    public void Attack(Transform target)
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Target = target;
        bullet.teamComponent.team = teamComponent.team;
    }
}