using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
    public HealthComponent healthComponent;
    private float maxHealth;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        maxHealth = healthComponent.health;
    }

    private void Update()
    {
        if (healthComponent != null)
        {
            image.fillAmount = healthComponent.health / maxHealth;
        }
        else
        {
            image.fillAmount = 0;
        }
    }
}
