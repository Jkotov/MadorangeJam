
using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{ 
    public float lifetime;
    private float startLifetime;
    private Material material;
    private static readonly int Alpha = Shader.PropertyToID("_Alpha");

    private void Awake()
    {
        startLifetime = lifetime;
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        material.SetFloat(Alpha, lifetime / startLifetime);
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
