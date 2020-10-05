using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecticalSwitch : MonoBehaviour
{
    public GameObject PointLightsOnMap;
    public bool isActivated = false;
    

    private void Start()
    {
        GetComponent<TimeConsumingTask>().OnInteract += ActivateTheLights;
        GetComponent<TimeConsumingTask>().OnInteract += MakeElecticPaddle;
    }
    public void ActivateTheLights()
    {
        PointLightsOnMap.SetActive(true);
        GameManager.instance.isActiveElectricity = true;
    }

    public void MakeElecticPaddle()
    {
        ElectricPuddleManager.instance.PlaceElectricPuddle();
    }
}
