using System.Numerics;

[System.Serializable]

// i've used '//' to notate that the save system work for the variable on that line

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
    public bool playerPosNewGame; 

    public int healthRegenRateUpgradeCount;  //
    public int staminaRegenRateUpgradeCount;

    public bool healthNewGame;  //
    public bool staminaNewGame; //

    //public Vector3 playerPosition;
    public int enemyNum; //
    public string[] enemyPositions; //

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
    public float shipHealth; //
    public bool shipNewGame; //

    //default values
    public GameData()
    {
        this.balance = 0;
        this.wood = 0;
        this.ore = 0;

        this.health = 100;
        this.healthRegenRate = 0.2f;
        this.stamina = 100;
        this.staminaRegenRate = 0.5f;
        this.playerPosNewGame = true;

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
        this.turretNum = 0;
        this.walls = false;
        this.turretFireRate = 1;
        this.turretRange = 15;

        this.turretFireRateUpgradeCount = 1;
        this.turretRangeUpgradeCount = 1;

        this.timeOfDay = 6.5f;
        this.dayNum = 1;
        this.shipHealth = 1000;
        this.shipNewGame = true;

        this.enemyNum = 0;
        this.enemyPositions = new string[0];
    }
}
