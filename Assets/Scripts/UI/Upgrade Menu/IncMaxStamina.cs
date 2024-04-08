using UnityEngine;

public class IncMaxStamina : ButtonBase
{
    public PlayerMotor playerStamina;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Stamina Increased by 10");
        playerStamina.IncreaseMaxStamina(10);

        UpgradeCount += UpgradeCount;
    }
}