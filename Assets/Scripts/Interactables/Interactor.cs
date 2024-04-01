using UnityEngine;
using TMPro;

interface IInteractable
{
    public void Interact();
    string InteractionPrompt { get; }
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public TextMeshProUGUI PromptText;

    void Update()
    {
        bool foundInteractable = false;

        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                PromptText.text = interactObj.InteractionPrompt;
                foundInteractable = true;

                //check for an interaction ('E')
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact();
                }
            }
        }

        //if user is not looking at anything, clear prompt
        if (!foundInteractable)
        {
            PromptText.text = "";
        }
    }
}
