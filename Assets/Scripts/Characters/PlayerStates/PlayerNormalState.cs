using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : State
{
    public PlayerNormalState(InputContoller _inputcontoller) : base(_inputcontoller) { }

    public override IEnumerator Move(Vector2 inp)
    {
        _inputcontoller.MovementController.Move(inp);
        yield break;
    }

    public override IEnumerator Interact()
    {
        BearTrapActivate();
        _inputcontoller.InteractonController.Interact(_inputcontoller);
        yield break;
    }

    private void BearTrapActivate()
    {
        // Logic for BearTrap
        if (Inventory.instance.GetInventoryLength() > 0)
        {
            Item currentItem = Inventory.instance.GetItemFromInventory(Inventory.instance.GetCurrentItemIndex()) ?? null;
            if (currentItem != null && (int)currentItem.id == 7) // If current item is BearTrap, then just use it
            {
                Debug.Log("You have activated bear trap");
                _inputcontoller.BearTrapSpawner.PlaceTrap();
            }
        }
    }
}
