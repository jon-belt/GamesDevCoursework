using UnityEngine;

public class BuyWalls : OneTimePurchaseButton
{
    public GameObject walls;
    protected override int ItemCost => 200;
    protected override string SuccessText => "Purchased";

    protected override void Start()
    {
        base.Start();
    }

    protected override void ApplyUpgrade()
    {
        walls.SetActive(true);
    }
}
