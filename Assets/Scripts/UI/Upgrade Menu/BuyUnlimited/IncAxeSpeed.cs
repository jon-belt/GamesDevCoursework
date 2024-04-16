using UnityEngine;

public class IncAxeSpeed : ButtonBase, IDataPersistence
{
    public Axe axe;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 5;
    protected override int BaseUpgradeCost => 15;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Axe Speed Increased");

        //strength is interchangable with 'speed' as it takes the user less time to mine the ore
        axe.IncStrength();

        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.axeSpeed;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.axeSpeed = this.upgradeCount;
    }
}