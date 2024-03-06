using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Interactable
{
    [SerializeField]
    public GameObject handFlashlight;

    protected override void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
        this.gameObject.SetActive(false);
        handFlashlight.SetActive(true);
    }
}
