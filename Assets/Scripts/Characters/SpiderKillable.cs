using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKillable : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TimeConsumingTask>().OnInteract += WeJustWon;
    }

    public void WeJustWon()
    {
        // todo 
    }
}
