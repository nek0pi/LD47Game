using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : InputContoller
{
    private void Awake()
    {
        KillManager = GetComponent<KillManager>();
        currentState = new EnemyNormalState(this);
    }

    private void FixedUpdate()
    {
        // Conditions to find and kill the player.
        // Once every specific frame (not every frame.)
        // Todo add some conditions
    }
    public override void OnMove(Vector2 inputVect)
    {
        Debug.Log("I'm looking for you");
    }

    public override void OnInteract()
    {
        Debug.Log("I've killed you");
    }
}
