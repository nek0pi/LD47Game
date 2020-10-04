using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour, IInteractible
{
    public int ObjectID;
    public Item ItemInside;
    public event Action OnInteract;
    public void Interact(InputContoller stateManager)
    {
        if(ItemInside != null)
        {
            DialogueManager.Instance.DialogueDisplayer.DisplayMessage($"You've found a {ItemInside.objectName}!");
            //todo add this item to your inventory
            OnInteract?.Invoke();
            return;
        }
        GetComponent<DialogueTrigger>().StartDialogue(ObjectID);
        OnInteract?.Invoke();
    }

}
