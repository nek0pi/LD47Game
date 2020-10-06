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

    private void Start()
    {
        GameManager.instance.onReset += OnReset;   
    }
    public void Interact(InputContoller stateManager)
    {
        if(ItemInside != null && hasPickedUpItem == false)
        {
            DialogueDisplayer.Instance.DisplayMessage($"You've found a {ItemInside.objectName}!");
            hasPickedUpItem = true;
            Inventory.instance.AddItemToInventory(ItemInside.id);
            return;
        }
        GetComponent<DialogueTrigger>().StartDialogue(ObjectID);
    }

    public void OnReset(int n) { GameManager.instance.onReset -= OnReset;  Destroy(gameObject); }

}
