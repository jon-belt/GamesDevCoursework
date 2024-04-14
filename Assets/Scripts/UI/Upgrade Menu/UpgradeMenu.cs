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

    private void OnEnable()
    {
        StartCoroutine(EnsureDataManagerReady());
    }

    private IEnumerator EnsureDataManagerReady()
    {
        while (DataPersistenceManager.instance == null)
        {
            Debug.Log("Waiting for DataPersistenceManager...");
            yield return null;
        }
        
        DataPersistenceManager.instance.ApplyDataWhenReady();
    }
}
