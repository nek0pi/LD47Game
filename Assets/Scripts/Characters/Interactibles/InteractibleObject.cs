using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour, IInteractible
{
    public int ObjectID;
    public void Interact(InputContoller stateManager)
    {
        GetComponent<DialogueTrigger>().StartDialogue(ObjectID);
    }

}
