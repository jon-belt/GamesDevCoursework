using UnityEngine;

public class IncMaxHealth : ButtonBase
{
    public PlayerHealth playerHealth;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Health Increased by 20");
        playerHealth.IncreaseHealth(20f);

        UpgradeCount += UpgradeCount;
    }
}