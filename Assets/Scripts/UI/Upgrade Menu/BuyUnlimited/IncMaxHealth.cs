using UnityEngine;

public class IncMaxHealth : ButtonBase, IDataPersistence
{
    public PlayerHealth playerHealth;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Health Increased by 20");
        playerHealth.IncreaseHealth(20f);
        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.maxHealth;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.maxHealth = this.upgradeCount;
    }
}
