using UnityEngine;

public class IncRegenStamina : ButtonBase
{
    public PlayerMotor playerStamina;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 5;
    protected override int BaseUpgradeCost => 15;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Stamina Regen Rate Increased by 0.1");
        playerStamina.IncreaseRegenRate(0.25f);

        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.staminaRegenRateUpgradeCount;
    }

    public void SaveData(ref GameData data)
    {
        data.staminaRegenRateUpgradeCount = this.upgradeCount;
    }
}