using UnityEngine;

public class IncAxeReward : ButtonBase, IDataPersistence
{
    public Axe axe;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Axe Reward Increased");

        axe.IncReward();

        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.axeReward;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.axeReward = this.upgradeCount;
    }
}