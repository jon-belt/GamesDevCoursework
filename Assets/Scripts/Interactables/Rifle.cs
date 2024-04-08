using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleInteractable : Interactable
{
    [SerializeField]
    private GameObject rifle;

    protected override void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
        this.gameObject.SetActive(false);
        rifle.SetActive(true);
    }
}
