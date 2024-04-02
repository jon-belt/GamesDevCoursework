using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.E) && this.gameObject.activeInHierarchy))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    
}
