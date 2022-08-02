using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : MonoBehaviour
{
    public GameObject puddlePrefab;
    void Update()
    {
        if (transform.position.y <= 0f)
        {
            Instantiate(puddlePrefab, transform.position, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
            Destroy(gameObject);
        }
    }
}
