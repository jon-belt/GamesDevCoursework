using UnityEngine;

public class BuyTimer : OneTimePurchaseButton, IDataPersistence
{
    public TimerLogic timerLogic;

    protected override int ItemCost => 50; //hard coded cost for timer
    protected override string SuccessText => "Purchased";

    protected override void ApplyUpgrade()
    {
        timerLogic.Purchase();
    }

    public void LoadData(GameData data)
    {
        this.purchased = data.timer;
        UpdateButtonUI();
    }

    public void SaveData(ref GameData data)
    {
        data.timer = this.purchased;
    }
}
