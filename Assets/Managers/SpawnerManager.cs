using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager instance;

    [SerializeField]
    private List<ItemTransform> allItemsOnMapToReset;

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
        InitializeManager();
    }

    private void InitializeManager()
    {
        GameManager.instance.onReset += OnWorldReset;
    }

    public void OnWorldReset(int itteration)
    {
        foreach (ItemTransform item in allItemsOnMapToReset)
        {
            Instantiate(item.item, item.whereToPlace.position, item.whereToPlace.localRotation);
        }
    }

    [System.Serializable]
    public class ItemTransform
    {
        public GameObject item;
        public Transform whereToPlace;
    }

}
