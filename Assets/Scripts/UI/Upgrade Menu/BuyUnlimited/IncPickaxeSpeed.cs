using UnityEngine;

public class IncPickaxeSpeed : ButtonBase, IDataPersistence
{
    public Pickaxe pickaxe;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Axe Speed Increased");

        //strength is interchangable with 'speed' as it takes the user less time to mine the
        pickaxe.IncStrength();

        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.pickaxeSpeed;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.pickaxeSpeed = this.upgradeCount;
    }
}