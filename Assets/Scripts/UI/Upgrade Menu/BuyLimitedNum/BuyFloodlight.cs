using UnityEngine;

public class BuyFloodlight : OneTimePurchaseButton, IDataPersistence
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

    public bool isPurchased()
    {
        if (this.purchased == true){return true;}
        else{return false;}
    }

    public void LoadData(GameData data)
    {
        this.purchased = data.floodLight;
        UpdateButtonUI();
        if (data.floodLight == true)
        {
            floodLight.SetActive(true);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.floodLight = this.purchased;
    }
}

