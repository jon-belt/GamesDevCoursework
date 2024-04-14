using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncRifleRange : ButtonBase
{
    public int UpgradeCount = 0;
    public Rifle rifle;

    protected override int UpgradePriceInc => 15;
    protected override int BaseUpgradeCost => 30;
    
    protected override void ApplyUpgrade()
    {
        Debug.Log("Gun Range Increased");

        rifle.IncRange(10);
        
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
