using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : Interactable
{
    [SerializeField]
    private GameObject button;

    protected override void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
        GetComponent<Animator>().SetTrigger("ButtonPress");
    }
}
