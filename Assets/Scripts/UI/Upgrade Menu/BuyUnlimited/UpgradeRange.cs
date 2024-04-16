using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRange : ButtonBase, IDataPersistence
{
    public TurretManager turretManager;
    private int upgradeCount = 0;
    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 40;
    protected override int UpgradeCount => upgradeCount;

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
        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.turretRangeUpgradeCount;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.turretRangeUpgradeCount = this.upgradeCount;
    }
}
