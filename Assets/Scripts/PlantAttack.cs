using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlantAttack : MonoBehaviour
{
    public List<Transform> attackTargets;
    public float animationNormalizedOffset;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Animator animator;
    public float attackCooldown;
    public Transform spawnPoint;
    private float lastAttackTime;
    private void Awake()
    {
        CalcAnims();
    }

    void Update()
    {
        if (lastAttackTime < Time.time - attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        lastAttackTime = Mathf.Floor(Time.time / attackCooldown) * attackCooldown + attackCooldown * animationNormalizedOffset;
        var target = attackTargets[Random.Range(0, attackTargets.Count)];
        transform.LookAt(target);
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        transform.rotation = Quaternion.Euler(eulerAngles);
        var bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity =
            (target.position - spawnPoint.position).normalized * bulletSpeed;
    }

    private void CalcAnims()
    {
        var attackClip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        var animLenght = attackClip.length;
        var animSpeed = animLenght / attackCooldown;
        lastAttackTime = attackCooldown * animationNormalizedOffset;
        animator.speed = animSpeed;
    }
}
