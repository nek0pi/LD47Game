using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBusyState : State
{
    private float _busyTime = 0;
    public PlayerBusyState(InputContoller _inputcontoller, float time) : base(_inputcontoller) { _busyTime = time; }

    public override IEnumerator Start()
    {
        _inputcontoller.StartCoroutine(GetBackToNormalState());
        yield break;
    }

    private IEnumerator GetBackToNormalState()  
    {
        yield return new WaitForSeconds(_busyTime);
        _inputcontoller.SetState(new PlayerNormalState(_inputcontoller));
    }
}
