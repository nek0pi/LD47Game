using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPit : MonoBehaviour
{
    public GameObject ElectrifiedPit;
    private void Start()
    {
        ElectrifyIt();
    }

    public void ElectrifyIt()
    {
        if (GameManager.instance.isActiveElectricity == true)
        {
            //todo make it turn into a different object
            Instantiate(ElectrifiedPit, transform.position, Quaternion.identity);
        }
    }
}
