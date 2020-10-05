using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrifiedWaterPit : MonoBehaviour
{
    public bool isActiveElectricity;
    public GameObject ElectrifiedPit;
    private void Start()
    {
        ElectrifyIt();
    }

    public void ElectrifyIt()
    {
        if (isActiveElectricity)
        {
            //todo make it turn into a different object
            Instantiate(ElectrifiedPit, transform.position, Quaternion.identity);
        }
    }
}
