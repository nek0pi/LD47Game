using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractonController : MonoBehaviour
{
    private IInteractible _interactible;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out _interactible);
        //todo make an object be highlighted when you are nearby
    }

    private void OnTriggerExit(Collider other)
    {
        other.TryGetComponent(out _interactible);
    }
    public void Interact(InputContoller _inputcontoller)
    {
        if(_interactible != null)
            _interactible.Interact(_inputcontoller);
    }

}