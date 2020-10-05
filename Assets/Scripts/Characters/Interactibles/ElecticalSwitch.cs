using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecticalSwitch : MonoBehaviour
{
    public GameObject PointLightsOnMap;
    public Transform PuddlesPosition;
    public GameObject ElectricPuddle;
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
        //if (GameManager.instance.isWaterPuddlePlaced == true)
        //{
        //    //todo make it so that the mud puddle with water is substituded with the puddle that is under load!
        //    //Search for the waterfilledhole object
        //    Instantiate(ElectricPuddle, PuddlesPosition.position, Quaternion.identity);
        //}
    }
}
