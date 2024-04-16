using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floodlight : MonoBehaviour
{
    public GameObject floodLight;
    public BuyFloodlight buyFloodlight;

    // Start is called before the first frame update
    void Start()
    {
        if (buyFloodlight.isPurchased() == true)
        {
            floodLight.SetActive(true);
        }
        else{
            floodLight.SetActive(false);
        }
    }
}

