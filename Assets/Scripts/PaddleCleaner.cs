using System;
using UnityEngine;

public class PaddleCleaner : MonoBehaviour
{
    public GameObject brush;
    public Animator animator;
    public float lifetimePerFrame;
    private static readonly int IsWorking = Animator.StringToHash("IsWorking");

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Paddle paddle))
        {
            animator.SetBool(IsWorking, true);
            brush.SetActive(true);
            paddle.lifetime -= lifetimePerFrame;
        }
    }
}