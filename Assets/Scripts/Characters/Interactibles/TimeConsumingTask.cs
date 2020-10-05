using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TimeConsumingTask : MonoBehaviour, IInteractible
{
    public int ObjectID;
    //Fill this in if you want this object to give you another object after interaction
    public Item ItemInside;
    public event Action OnInteract;


    private bool hasFinishedTask = false;
    public float timeConsumes;
    public Item ItemForInteraction;
    private DialogueTrigger dialogueTrigger;
    public AudioClip AssociatedSound;
    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }
    public void Interact(InputContoller inputController)
    {
        // If there is more than 1 item in inventory
        if (Inventory.instance.GetInventoryLength() > 0 && hasFinishedTask == false && ItemForInteraction != null)
        {
            // If current item is the item needed for interaction then...
            try
            {
                Item currentItem = Inventory.instance.GetItemFromInventory(Inventory.instance.GetCurrentItemIndex()) ?? null;
                // If current item is the item needed for interaction then...
                if (currentItem != null && (int)currentItem.id == (int)ItemForInteraction.id)
                {
                    StartWorking(inputController);
                    hasFinishedTask = true;
                }
                else { dialogueTrigger.StartDialogue(ObjectID); }
            }
            // If there are any problems with code above, juse fire a dialogue
            catch (Exception)
            {
                dialogueTrigger.StartDialogue(ObjectID);
                throw;
            }
            
        }

        else
        {
            if(ItemForInteraction == null) { StartWorking(inputController); return; }
            dialogueTrigger.StartDialogue(ObjectID);
            
        }
    }

    private void StartWorking(InputContoller inputController)
    {
        // todo Remove Used Item from inventory
        

        //Loading bar appears and make it be filled with time
        LoadingBar.Instance.UISlider.gameObject.SetActive(true);
        LoadingBar.Instance.StartLoading(timeConsumes);

        //Transition player to a busy state
        inputController.SetState(new PlayerBusyState(inputController, timeConsumes));

        //Start a timer at the end of which invoke a delegate and potentially give an item to a player
        StartCoroutine(AfterTaskEvents());

        //todo Start the sound of bucket filling
        if (AssociatedSound != null)
        {
            GetComponent<AudioSource>().clip = AssociatedSound;
            GetComponent<AudioSource>().Play();
        }
            

    }

    IEnumerator AfterTaskEvents()
    {
        yield return new WaitForSeconds(timeConsumes);

        OnInteract?.Invoke();
        LoadingBar.Instance.UISlider.gameObject.SetActive(false);
        LoadingBar.Instance.Reset();

        if (ItemInside != null)
        {
            DialogueDisplayer.Instance.DisplayMessage($"You've got a {ItemInside.objectName}.");
            Inventory.instance.AddItemToInventory(ItemInside.id);
        }
    }
}
