using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalance : MonoBehaviour
{
    [SerializeField]public float balance;

    void Start()
    {
        balance = 0f;
    }

    public void AddToBalance(float amount)
    {
        balance += amount;
    }
}
