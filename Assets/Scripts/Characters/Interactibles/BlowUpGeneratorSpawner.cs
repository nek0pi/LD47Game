using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpGeneratorSpawner : MonoBehaviour
{
    public GameObject blownGenerator;
    public static BlowUpGeneratorSpawner instance;
    public Transform placeToSpawn;
    public event Action RemoveGen;
    private void Start()
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

    public void SpawnGenerator()
    {
        Instantiate(blownGenerator, placeToSpawn.position, Quaternion.identity);
        RemoveGen?.Invoke();
    }
}
