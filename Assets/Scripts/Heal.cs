using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public HealthComponent healthComponent;
    public float healSpeed;
    private float maxHealth;

    private void Awake()
    {
        maxHealth = healthComponent.Health;
    }

    private void Update()
    {
        healthComponent.Health += healSpeed * Time.deltaTime;
        healthComponent.Health = healthComponent.Health > maxHealth ? maxHealth : healthComponent.health;
    }
}
