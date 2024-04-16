using UnityEngine;

public class BuyWalls : OneTimePurchaseButton, IDataPersistence
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

    public bool isPurchased()
    {
        if (this.purchased == true){return true;}
        else{return false;}
    }

    public void LoadData(GameData data)
    {
        this.purchased = data.walls;
        UpdateButtonUI();
        if (data.walls == true)
        {
            walls.SetActive(true);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.walls = this.purchased;
    }
}

