using UnityEngine;

public class BuyFloodlight : OneTimePurchaseButton
{
    public GameObject floodLight;
    protected override int ItemCost => 100;
    protected override string SuccessText => "Purchased";

    protected override void Start()
    {
        base.Start();
    }

    protected override void ApplyUpgrade()
    {
        floodLight.SetActive(true);
    }
}

