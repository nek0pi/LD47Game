using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalState : State
{
    public EnemyNormalState(EnemyController _inputcontoller) : base(_inputcontoller) { }

    public override IEnumerator Interact()
    {
        _inputcontoller.KillManager();
        yield break;
    }
}
