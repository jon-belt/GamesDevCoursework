using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IDataPersistence
{
    [SerializeField]public float balance = 0f;
    [SerializeField]public float ore = 0f;
    [SerializeField]public float wood= 0f;

    // void Start()
    // {
    //     balance = 0f;
    //     ore = 0f;
    //     wood = 0f;
    // }

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

    //Save interface methods
    public void LoadData(GameData data)
    {
        this.balance = data.balance;
    }

    public void SaveData(ref GameData data)
    {
        data.balance = this.balance;
    }
}
