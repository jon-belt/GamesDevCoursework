using UnityEngine;

public class IncMaxStamina : ButtonBase, IDataPersistence
{
    public PlayerMotor playerStamina;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Stamina Increased by 10");
        playerStamina.IncreaseMaxStamina(10);

        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.maxStamina;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.maxStamina = this.upgradeCount;
    }
}