using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    protected override void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
        doorOpen = !doorOpen;                                       //toggles door open and close
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);  //tells the animator to run the animation
    }
}
