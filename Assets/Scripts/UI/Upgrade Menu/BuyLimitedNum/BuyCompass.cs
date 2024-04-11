using UnityEngine;

public class BuyCompass : OneTimePurchaseButton
{
    public CompassTrack compass;
    public HotbarManager hotbarManager;

    protected override int ItemCost => 100; //hard coded cost for compass
    protected override string SuccessText => "Purchased";

    protected override void ApplyUpgrade()
    {
        hotbarManager.PurchaseCompass();
    }
}
