using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoisonBullet : MonoBehaviour
{
    public GameObject puddlePrefab;
    public Vector3 maxAngularVelocity;

    private void Awake()
    {
        var x = Random.Range(0, maxAngularVelocity.x);
        var y = Random.Range(0, maxAngularVelocity.y);
        var z = Random.Range(0, maxAngularVelocity.z);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(x, y, z);
    }

    void Update()
    {
        if (transform.position.y <= 0f)
        {
            Instantiate(puddlePrefab, new Vector3(transform.position.x, 0, transform.position.z),
                Quaternion.Euler(0, Random.Range(0f, 360f), 0));
            Destroy(gameObject);
        }
    }
}
