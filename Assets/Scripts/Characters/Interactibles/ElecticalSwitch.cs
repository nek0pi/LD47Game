using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecticalSwitch : MonoBehaviour
{
    public GameObject[] PointLightsOnMap;
    private bool isActivated = false;


    private void Start()
    {
        GetComponent<TimeConsumingTask>().OnInteract += ActivateTheLights;
    }
    public void ActivateTheLights()
    {
        foreach (var item in PointLightsOnMap)
        {
            item.SetActive(true);
        }
        isActivated = true;
    }

    public void MakeElecticPaddle()
    {
        if (isActivated)
        {
            //todo check if there is *Some water puddle object* and if there is make the area eletcric
            // Subscribe to some event of the manager somewhere to enable this thing!

        }
    }
}
