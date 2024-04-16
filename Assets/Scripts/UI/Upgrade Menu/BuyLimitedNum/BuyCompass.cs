using UnityEngine;

public class BuyCompass : OneTimePurchaseButton, IDataPersistence
{
    public CompassTrack compass;
    public HotbarManager hotbarManager;

    protected override int ItemCost => 100; //hard coded cost for compass
    protected override string SuccessText => "Purchased";

    protected override void ApplyUpgrade()
    {
        purchased = true;
        hotbarManager.PurchaseCompass();
    }

    public void LoadData(GameData data)
    {
        this.purchased = data.compass;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.compass = this.purchased;
    }
}
