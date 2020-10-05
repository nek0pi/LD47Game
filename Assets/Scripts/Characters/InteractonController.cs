using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractonController : MonoBehaviour
{
    private IInteractible _interactible;
    private List<GameObject> interactibles = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {

            if (interactibles.Contains(collision.gameObject) == false)
            {
                UnhighlightLast();

                interactibles.Add(collision.gameObject);

                HighlightLast();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {

            if (interactibles.Contains(collision.gameObject))
            {
                UnhighlightLast();
                interactibles.Remove(collision.gameObject);
                HighlightLast();
            }

            //_interactible = null;
        }
    }

    public void Interact(InputContoller _inputcontoller)
    {
        if (interactibles.Count != 0)
            interactibles.Last().GetComponent<IInteractible>().Interact(_inputcontoller);

        //if (_interactible != null)
            //_interactible.Interact(_inputcontoller);
    }
    private void HighlightLast()
    {
        if (interactibles.Count != 0)
            interactibles.Last().GetComponent<SpriteRenderer>().material.SetFloat("_OutlineEnabled", 1);
    }

    private void UnhighlightLast()
    {
        //Unhighlight the previous one
        if (interactibles.Count != 0)
            interactibles.Last().GetComponent<SpriteRenderer>().material.SetFloat("_OutlineEnabled", 0);
    }

}