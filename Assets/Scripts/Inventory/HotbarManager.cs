//this script handles the logic between switching items using the 1-9 keys

using UnityEngine;

public class HotbarManager : MonoBehaviour, IDataPersistence
{
    public GameObject[] items;  //list of holdable items
    private int currentIndex = -1;

    //these two bools ensure the user cannot bring out item they have not purchased yet
    private bool compassPurchased = false;

    void Update()
    {
        for(int i = 0; i < items.Length; i++)
        {
            //every frame, script checks if user has pressed
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                SwitchItem(i);
                break;
            }
        }
    }
    void SwitchItem(int index)
    {
        //hide current item
        if (currentIndex != -1)
        {
            items[currentIndex].SetActive(false);
        }

        //next two if statements end the script if the compass or sniper has not been purchased
        //probably not the best way to do it, but it works
        if (items[index].name == "Compass" && compassPurchased == false)
        {
            return;
        }

        //show item
        items[index].SetActive(true);
        currentIndex = index;   //update the current index
    }

    public void PurchaseCompass()
    {
        compassPurchased = true;
    }

    public void LoadData(GameData data)
    {
        this.compassPurchased = data.compass;
    }

    public void SaveData(ref GameData data)
    {
        data.compass = this.compassPurchased;
    }
}
