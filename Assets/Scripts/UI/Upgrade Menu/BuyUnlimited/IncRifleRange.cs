using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncRifleRange : ButtonBase
{
    public Rifle rifle;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 15;
    protected override int BaseUpgradeCost => 30;
    protected override int UpgradeCount => upgradeCount;
    
    protected override void ApplyUpgrade()
    {
        Debug.Log("Gun Range Increased");

        rifle.IncRange(10);
        
        upgradeCount += 1;
    }
    public void LoadData(GameData data)
    {
        this.upgradeCount = data.rifleRange;
    }

    public void SaveData(ref GameData data)
    {
        data.rifleRange = this.upgradeCount;
    }
}
