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
        _inputcontoller.InteractonController.Interact(_inputcontoller);
        yield break;
    }
}
