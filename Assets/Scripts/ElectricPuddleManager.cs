using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPuddleManager : MonoBehaviour
{
    public static ElectricPuddleManager instance;
    public Transform placeforPit;
    public GameObject ElectrifiedPitPref;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public bool PlaceElectricPuddle()
    {
        if (GameManager.instance.isActiveElectricity == true && GameManager.instance.isWaterPuddlePlaced == true)
        {
            // make it turn into an electrified pit
            Instantiate(ElectrifiedPitPref, placeforPit.position, Quaternion.identity);
            return true;
        }
        return false;
    }

}
