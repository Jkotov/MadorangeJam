using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TeamComponent))]
public class Bullet : MonoBehaviour
{
    public TeamComponent teamComponent;
    public float speed;
    public float damage;

    private void Awake()
    {
        teamComponent = GetComponent<TeamComponent>();
    }

    public Transform Target
    {
        get => target;
        set
        {
            StopAllCoroutines();
            target = value;
            if (target != null)
                StartCoroutine(MoveRoutine());
        }
    }

    private Transform target;

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            yield return null;
            if (target == null)
            {
                Destroy(gameObject);
                yield break;
            }
            transform.position += speed * Time.deltaTime * (Target.position - transform.position).normalized;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthComponent health))
        {
            if (health.teamComponent.team == teamComponent.team)
                return;
            health.Health -= damage;
            Destroy(gameObject);
        }
    }
}
