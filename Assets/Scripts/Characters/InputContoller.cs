using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputContoller : StateMachine
{
    [HideInInspector]
    public MovementController MovementController;
    [HideInInspector]
    public InteractonController InteractonController;

    private void Awake()
    {
        MovementController = GetComponent<MovementController>();
        InteractonController = GetComponent<InteractonController>();
        currentState = new PlayerNormalState(this);

    }
    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMove(input);

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }

    }

    public virtual void OnMove(Vector2 inputVect)
    {
        if (currentState != null)
            StartCoroutine(currentState.Move(inputVect));
    }

    public virtual void OnInteract()
    {
        if (currentState != null)
            StartCoroutine(currentState.Interact());
    }

}
