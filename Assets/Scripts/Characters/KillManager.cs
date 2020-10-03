
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    private GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { target = other.gameObject; }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { target = null; }

    }

    public void Attack()
    {
        if (target != null)
        {
            Debug.Log("Player has died");
            DeathManager.Die();
        }
    }
}
