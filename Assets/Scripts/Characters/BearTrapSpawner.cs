using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapSpawner : KillingObject
{
    public GameObject bearTrapObj;

    public void PlaceTrap()
    {
        bearTrapObj.SetActive(true);
    }
}
