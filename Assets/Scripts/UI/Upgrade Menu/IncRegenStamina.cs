using UnityEngine;

public class IncRegenStamina : ButtonBase
{
    public PlayerMotor playerStamina;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 5;
    protected override int BaseUpgradeCost => 15;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Stamina Regen Rate Increased by 0.1");
        playerStamina.IncreaseRegenRate(0.25f);

        UpgradeCount += UpgradeCount;
    }
}