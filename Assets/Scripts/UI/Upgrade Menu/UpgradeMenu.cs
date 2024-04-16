using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeMenuUI;
    public PlayerMotor playerMotor;
    public PlayerLook playerLook;
    public DataPersistenceManager dataPersistenceManager;

    void Start()
    {
        // Start the coroutine
        StartCoroutine(HideAfterDelay());
    }

    //because of how i set up the upgrade menu, unfortunaely i have to use this weird workaround to disable the menu after a millisecond
    //this is because the menu needs to be active in the scene for the save mechanic to work
    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(0.001f);
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
