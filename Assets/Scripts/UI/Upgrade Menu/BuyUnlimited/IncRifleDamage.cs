using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncRifleDamage : ButtonBase, IDataPersistence
{
    private int upgradeCount = 0;
    public Rifle rifle;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Gun Damaged Increased");

        rifle.IncDamage(5);

        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.rifleDamage;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.rifleDamage = this.upgradeCount;
    }
}
