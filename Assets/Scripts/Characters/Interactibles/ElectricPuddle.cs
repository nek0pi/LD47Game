using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPuddle : MonoBehaviour
{

    private void Start()
    {
        GameManager.instance.onReset += OnReset;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Todo kill him
            DeathManager.Instance.Die();
        }
        else if (other.CompareTag("Enemy"))
        {
           // Stun an enemy
        }
    }

    public void OnReset(int n) { Destroy(gameObject); }
}
