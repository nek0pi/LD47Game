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

    private void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            if (KillManager.Target != null)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        if(currentState != null)
            StartCoroutine(currentState.Attack());
    }
}
