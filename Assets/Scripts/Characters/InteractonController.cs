using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractonController : MonoBehaviour
{
    private IInteractible _interactible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Interactable"))
            collision.TryGetComponent(out _interactible);
            //todo make an object be highlighted when you are nearby
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactible = null;
        }
    }

    public void Interact(InputContoller _inputcontoller)
    {
        if(_interactible != null)
            _interactible.Interact(_inputcontoller);
    }

}