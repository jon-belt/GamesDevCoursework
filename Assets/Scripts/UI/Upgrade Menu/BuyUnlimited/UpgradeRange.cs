using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRange : ButtonBase
{
    public TurretManager turretManager;
    public int UpgradeCount;
    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 50;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Turret Range Increased");

        // increase range for all turrets
        for (int i = 0; i < turretManager.turretsBought; i++)
        {
            GameObject turretObject = turretManager.turrets[i];
            Turret turret = turretObject.GetComponent<Turret>();
            if (turret != null)
            {
                turret.increaseRange();
            }
        }
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
