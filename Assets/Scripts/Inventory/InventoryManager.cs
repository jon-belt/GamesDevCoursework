using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] items;  //list of holdable items
    private int currentIndex = -1;

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

        //show current item
        items[index].SetActive(true);
        currentIndex = index; // Update the current index
    }
}
