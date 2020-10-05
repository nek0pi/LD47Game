using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunnedState : State
{
    private float timetowait = 0;
    public EnemyStunnedState(EnemyController _inputcontoller) : base(_inputcontoller) {  }

}
