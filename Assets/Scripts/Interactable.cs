using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //add or remove an InteractionEvent component to this gameobject
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    //base interaction logic for the object.
    public void BaseInteract()
    {
        //check if events are enabled for the object
        if(useEvents){
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }

    //empty method to be overwritten by subclasses
    protected virtual void Interact(){

    }
}
