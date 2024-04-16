using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    //inventory - done
    public float balance;
    public float wood;
    public float ore;

    //player statistics
    public float health; //
    public float healthRegenRate; //
    public float stamina; //
    public float staminaRegenRate; //

    public int healthRegenRateUpgradeCount;  //
    public int staminaRegenRateUpgradeCount;

    public bool healthNewGame;  //
    public bool staminaNewGame; //

    //player position

    //upgrade counts
    //tool statistics
    public int axeReward; //
    public int axeSpeed; //
    public int pickaxeReward; //
    public int pickaxeSpeed; //
    public int rifleDamage; //
    public int rifleRange; //

    public int maxHealth; //

    //base statistics
    public bool compass;
    public bool timer;
    public bool turretUnlock;
    public int turretNum;
    public int turretFireRate;
    public int turretRange;
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
        this.wood = 0;
        this.ore = 0;

        this.health = 100;
        this.healthRegenRate = 0.2f;
        this.stamina = 100;
        this.staminaRegenRate = 0.5f;

        this.healthRegenRateUpgradeCount = 0;
        this.staminaRegenRateUpgradeCount = 0;

        this.axeReward = 0;
        this.axeSpeed = 0;
        this.pickaxeReward = 0;
        this.pickaxeSpeed = 0;
        this.rifleDamage = 0;
        this.rifleRange = 0;

        this.compass = false;
        this.timer = false;
        this.turretUnlock = false;
        this.turretNum = 0;
        this.walls = false;
        this.turretFireRate = 15;
        this.turretRange = 1;

        this.timeOfDay = 7;
        this.dayNum = 1;
        this.shipHealth = 0;
    }
}
