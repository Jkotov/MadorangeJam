using System;
using System.Collections.Generic;
using UnityEngine;

public class AgentWithTagDestroyerWithCash : MonoBehaviour
{
    [SerializeField] private string agentTag;
    [SerializeField] private int moneyPerDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(agentTag))
        {
            Destroy(other.gameObject);
            MoneyManager.Instance.Add(moneyPerDestroy);
        }
    }
}