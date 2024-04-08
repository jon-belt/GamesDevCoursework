using UnityEngine;

public class IncRegenHealth : ButtonBase
{
    public PlayerHealth playerHealth;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 5;
    protected override int BaseUpgradeCost => 15;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Regen Rate Increased by 0.1");
        playerHealth.IncreaseRegenRate(0.1f);

        UpgradeCount += UpgradeCount;
    }
}