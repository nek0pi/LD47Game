using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeConsumingTask : MonoBehaviour, IInteractible
{
    public int ObjectID;
    public Item ItemInside;
    public event Action OnInteract;
    private bool hasPickedUpItem = false;
    public void Interact(InputContoller stateManager)
    {

    }
}
