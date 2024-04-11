using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floodlight : MonoBehaviour
{
    public GameObject floodLight;

    // Start is called before the first frame update
    void Start()
    {
        floodLight.SetActive(false);
    }
}

