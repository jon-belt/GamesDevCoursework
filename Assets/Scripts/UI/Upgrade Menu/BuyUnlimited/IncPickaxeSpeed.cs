using UnityEngine;

public class IncPickaxeSpeed : ButtonBase
{
    public Pickaxe pickaxe;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Axe Speed Increased");

        //strength is interchangable with 'speed' as it takes the user less time to mine the
        pickaxe.IncStrength();

        UpgradeCount += 1;
    }

    public override ButtonSaveData GetSaveData()
    {
        var baseData = base.GetSaveData();
        baseData.upgradeCount = this.UpgradeCount;
        return baseData;
    }

    public override void SetSaveData(ButtonSaveData saveData)
    {
        base.SetSaveData(saveData);
        this.UpgradeCount = saveData.upgradeCount;
    }    
}