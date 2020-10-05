using System.Collections;
using UnityEngine;

public abstract class State
{
    protected readonly InputContoller _inputcontoller;

    public State(InputContoller sm)
    {
        _inputcontoller = sm;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Exit()
    {
        yield break;
    }
    public virtual IEnumerator Move(Vector2 input)
    {
        yield break;
    }

    public virtual IEnumerator Interact()
    {
        yield break;
    }

    public virtual IEnumerator Attack()
    {
        yield break;
    }
}
