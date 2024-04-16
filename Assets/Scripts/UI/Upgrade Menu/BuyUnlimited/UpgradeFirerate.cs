using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFirerate : ButtonBase, IDataPersistence
{
    public TurretManager turretManager;
    private int upgradeCount = 0;
    
    protected override int UpgradePriceInc => 25;
    protected override int BaseUpgradeCost => 75;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Turret Firerate Increased");

        // increase firerate for all turrets
        for (int i = 0; i < turretManager.turretsBought; i++)
        {
            GameObject turretObject = turretManager.turrets[i];
            Turret turret = turretObject.GetComponent<Turret>();
            if (turret != null)
            {
                turret.increaseFirerate();
            }
        }
        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.turretFireRateUpgradeCount;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.turretFireRateUpgradeCount = this.upgradeCount;
    }
}