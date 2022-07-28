using System;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }
    public TextMeshProUGUI text;
    private int Money
    {
        get => money;
        set
        {
            money = value;
            text.text = money.ToString();
        }
    }

    [SerializeField] private int money;
    
    public void Add(int addedMoney)
    {
        Money += addedMoney;
    }

    public bool TrySpend(int needMoney)
    {
        if (Money - needMoney >= 0)
        {
            Money -= needMoney;
            return true;
        }
        return false;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        text.text = money.ToString();
    }
}