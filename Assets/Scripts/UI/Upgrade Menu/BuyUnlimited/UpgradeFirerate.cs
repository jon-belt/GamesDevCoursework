using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFirerate : ButtonBase
{
    public TurretManager turretManager;
    protected override int UpgradePriceInc => 25;
    protected override int BaseUpgradeCost => 100;

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
    }
}