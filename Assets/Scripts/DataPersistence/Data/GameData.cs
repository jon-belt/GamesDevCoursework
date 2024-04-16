using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    //inventory
    public float balance; //
    public float wood; //
    public float ore; //

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
    public int maxStamina; //

    //base statistics
    public bool compass; //
    public bool timer;
    public bool floodLight; //
    //public bool turretUnlock;
    public int turretNum; //
    public float turretFireRate; //
    public float turretRange; //
    public int turretFireRateUpgradeCount; //
    public int turretRangeUpgradeCount; //
    public bool walls; //


    //other
    public float timeOfDay; //
    public int dayNum; //
    public bool lightingManagerNewGame; //
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
        //this.healthNewGame = true;
        //this.staminaNewGame = true;

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
        this.floodLight = false;
        //this.turretUnlock = false;
        this.turretNum = 0;
        this.walls = false;
        this.turretFireRate = 1;
        this.turretRange = 15;

        this.turretFireRateUpgradeCount = 1;
        this.turretRangeUpgradeCount = 1;

        this.timeOfDay = 6.5f;
        this.dayNum = 1;
        //this.lightingManagerNewGame = true;
        this.shipHealth = 1000;
    }
}
