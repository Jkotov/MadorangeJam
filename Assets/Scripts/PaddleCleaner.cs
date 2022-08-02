using System;
using UnityEngine;

public class PaddleCleaner : MonoBehaviour
{
    public float lifetimePerFrame;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Paddle paddle))
            paddle.lifetime -= lifetimePerFrame;
    }
}