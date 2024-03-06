using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 4f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets UI message to empty
        playerUI.UpdateText(string.Empty);
        
        //creates an invisible ray from the players camera (head) which points at what they're looking at
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // stores collision info

        //checks if the raycast hits an object
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            //checks if object is an interactable one
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();      //set variable to interactable object
                playerUI.UpdateText(interactable.promptMessage);    //update prompt to UI

                //check if object is interacted with
                if(inputManager.OnFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
