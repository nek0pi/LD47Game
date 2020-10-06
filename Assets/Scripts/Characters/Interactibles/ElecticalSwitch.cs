using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecticalSwitch : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TimeConsumingTask>().OnInteract += ActivateTheLights;
        GetComponent<TimeConsumingTask>().OnInteract += MakeElecticPaddle;
    }
    public void ActivateTheLights()
    {
        GameManager.instance.Lights.SetActive(true);
        GameManager.instance.isActiveElectricity = true;
    }

    public void MakeElecticPaddle()
    {
        ElectricPuddleManager.instance.PlaceElectricPuddle();
    }
}
