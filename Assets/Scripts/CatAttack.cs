using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CatAttack : AttackComponent
{
    public Transform attackPoint;
    public float timeBeforeAttack;
    private float currentAngle;
    private float nextAngle;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttack");


    public override void Attack(Transform target)
    {
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
        if (target == null)
            yield break;
        var bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Target = target;
        bullet.teamComponent.team = teamComponent.team;
    }
}
