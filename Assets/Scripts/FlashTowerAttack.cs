using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FlashTowerAttack : AttackComponent
{
    public float animationNormalizedPing;
    public Animator animator;
    public Transform attackPoint;
    private float timeBeforeAttack;
    private float currentAngle;
    private float nextAngle;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttack");

    protected override void Awake()
    {
        base.Awake();
        CalcAnim();
    }

    public override void Attack(Transform target)
    {
        animator.SetBool(IsAttacking, true);
        currentAngle = transform.rotation.eulerAngles.y;
        transform.LookAt(target);
        nextAngle = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(new Vector3(0, currentAngle, 0));
        StartCoroutine(AttackRoutine(target));
        transform.DORotate(new Vector3(0, nextAngle, 0), timeBeforeAttack);
    }

    private IEnumerator AttackRoutine(Transform target)
    {
        yield return new WaitForSeconds(timeBeforeAttack);
        animator.SetBool(IsAttacking, false);
        if (target == null)
            yield break;
        var bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Target = target;
        bullet.teamComponent.team = teamComponent.team;
    }

    
    private void CalcAnim()
    {
        var attackClip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        var animLenght = attackClip.length;
        var animSpeed = animLenght / attackCooldown;
        animator.speed = animSpeed;
        timeBeforeAttack = animationNormalizedPing * animLenght * animSpeed;
    }
}
