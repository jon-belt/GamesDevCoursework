using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]public float balance;
    [SerializeField]public float ore;
    [SerializeField]public float wood;

    void Start()
    {
        balance = 0f;
        ore = 0f;
        wood = 0f;
    }

    //balance methods
    public float GetBalance()
    {
        return balance;
    }
    public void AddToBalance(float amount)
    {
        balance += amount;
    }
    public void RemoveFromBalance(float amount)
    {
        balance -= amount;
    }

    //ore methods
    public float GetOre()
    {
        return ore;
    }
    public void AddToOre(float amount)
    {
        ore += amount;
    }
    public void RemoveFromOre(float amount)
    {
        ore -= amount;
    }

    //wood methods
    public float GetWood()
    {
        return wood;
    }
    public void AddToWood(float amount)
    {
        wood += amount;
    }
    public void RemoveFromWood(float amount)
    {
        wood -= amount;
    }
}
