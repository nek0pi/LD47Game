using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecticalSwitch : MonoBehaviour
{
    public GameObject PointLightsOnMap;
    public bool isActivated = false;


    private void Start()
    {
        if(isActivated == false)
            GetComponent<TimeConsumingTask>().OnInteract += ActivateTheLights;
    }
    public void ActivateTheLights()
    {
        PointLightsOnMap.SetActive(true);
    }

    public void MakeElecticPaddle()
    {
        if (isActivated)
        {
            //todo make it so that the mud puddle with water is substituded with the puddle that is under load!
        }
    }
}
