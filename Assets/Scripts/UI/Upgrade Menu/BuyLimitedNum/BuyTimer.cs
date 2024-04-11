using UnityEngine;

public class BuyTimer : OneTimePurchaseButton
{
    public TimerLogic timerLogic;

    protected override int ItemCost => 50; //hard coded cost for timer
    protected override string SuccessText => "Purchased";

    protected override void ApplyUpgrade()
    {
        timerLogic.Purchase();
    }
}
