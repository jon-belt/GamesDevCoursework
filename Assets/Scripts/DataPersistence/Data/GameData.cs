using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    //inventory
    public float balance;
    public float wood;
    public float ore;

    //player statistics
    public float health;
    public float healthRegenRate;
    public float stamina;
    public float staminaRegenRate;
    //player position

    //tool statistics
    public float axeReward;
    public float axeSpeed;
    public float pickaxeReward;
    public float pickaxeSpeed;
    public float rifleDamage;
    public float rifleRange;

    //base statistics
    public bool compass;
    public bool timer;
    public bool turretUnlock;
    public float turretNum;
    public bool walls;

    //other
    public float timeOfDay;
    public float dayNum;
    public float shipHealth;
    //enemy position


    public GameData()
    {
        //default values
        this.balance = 0;
    }
}
