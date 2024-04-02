using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeStation : MonoBehaviour, IInteractable
{
    public string InteractionPrompt => "Press E for Upgrade Station";
    public UpgradeMenu upgradeMenu;

    public void Interact()
    {
        upgradeMenu.Show();
    }
}
