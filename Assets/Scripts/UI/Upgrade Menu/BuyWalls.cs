using TMPro;
using UnityEngine;

public class BuyWalls : MonoBehaviour
{
    public TextMeshProUGUI  buttonText;
    public PlayerInventory playerInventory;

    public GameObject walls;

    private bool purchased;

    void Start()
    {
        purchased = false;
        //walls = GameObject.Find("SpaceshipWalls");
        walls.SetActive(false);
    }


    //similar version of the other button scripts, however everything is hard coded as the compass is only purchased once
    protected virtual void PurchaseUpgrade()
    {
        if (purchased == false){
            if (playerInventory.balance >= 100)
            {
                playerInventory.balance -= 100;
                purchased = true;
                ApplyUpgrade();     //runs logic after button has been pressed
                buttonText.text = "Purchased!";
            }
            else{Debug.Log("Not enough balance.");}
        }
        else{Debug.Log("Compass already purchased.");}
    }

    private void ApplyUpgrade()
    {
        Debug.Log("Walls Purchased");
        walls.SetActive(true);
    }

    public void OnUpgradeButtonClicked()
    {
        PurchaseUpgrade();
    }
}
