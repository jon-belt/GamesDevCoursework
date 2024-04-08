using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeMenuUI;
    public PlayerMotor playerMotor;
    public PlayerLook playerLook;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.E) && this.gameObject.activeInHierarchy))
        {
            this.gameObject.SetActive(false);
            playerMotor.canMove = true;
            playerLook.canLookAround = true;
        }
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        bool isMenuActive = upgradeMenuUI.activeSelf;

        playerMotor.canMove = false;
        playerLook.canLookAround = false;
    }    
}
