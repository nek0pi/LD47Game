using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager instance;
    public float waitTime = 1.5f;
    [SerializeField]
    private List<ItemTransform> allItemsOnMapToReset;
    [SerializeField]
    private ItemTransform playerItem;
    [SerializeField]
    private ItemTransform enemyItem;
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
        Ressurect();
        PlaceEnemy();

    }

    private void PlaceEnemy()
    {
        enemyItem.item.SetActive(false);
        enemyItem.item.transform.position = enemyItem.whereToPlace.position;
    }

    private void Ressurect()
    {
        var ic = playerItem.item.GetComponent<InputContoller>();
        ic.SetState(new PlayerNormalState(ic));
        ic.GetComponent<MovementController>().CharAnimator.SetBool("isDead", false);
        ic.transform.position = playerItem.whereToPlace.position;

    }
    [System.Serializable]
    public class ItemTransform
    {
        public GameObject item;
        public Transform whereToPlace;
    }

}
