using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour, IInteractible
{
    public int ObjectID;
    public Item ItemInside;
    public event Action OnInteract;
    private bool hasPickedUpItem = false;
    
    public void Interact(InputContoller stateManager)
    {
        

        if(ItemInside != null && hasPickedUpItem == false)
        {
            DialogueManager.Instance.DialogueDisplayer.DisplayMessage($"You've found a {ItemInside.objectName}!");
            hasPickedUpItem = true;
            Inventory.instance.AddItemToInventory(ItemInside.id);
            return;
        }
        GetComponent<DialogueTrigger>().StartDialogue(ObjectID);
    }

}
