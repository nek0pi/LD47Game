using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputContoller : StateMachine
{
    [HideInInspector]
    public MovementController MovementController;
    [HideInInspector]
    public InteractonController InteractonController;
    [HideInInspector]
    public KillManager KillManager;
    [HideInInspector]
    public BearTrapSpawner BearTrapSpawner;

    private void Awake()
    {
        MovementController = GetComponent<MovementController>();
        InteractonController = GetComponent<InteractonController>();
        BearTrapSpawner = GetComponent<BearTrapSpawner>();
        currentState = new PlayerNormalState(this);

    }
    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(input);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

    }

    private void Interact()
    {
        if (currentState != null)
            StartCoroutine(currentState.Interact());
    }

    private void Move(Vector2 input)
    {
        if (currentState != null)
            StartCoroutine(currentState.Move(input));
    }
}
