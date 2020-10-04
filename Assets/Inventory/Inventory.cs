using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public static Inventory instance = null;

    private delegate void OnItemAdd();
    private event OnItemAdd onItemAdd;

    private delegate void OnCurrentItemChanged(int currentItem);
    private event OnCurrentItemChanged onCurrentItemChanged;

    [SerializeField]
    private List<Item> itemsList;
    [SerializeField]
    private ShowInventory showInventory;

    private List<Item> allItems;
    private Dictionary<int, Item> itemsMap;

    [SerializeField]
    private int inventoryCapacity = 9;
    private int currentItem = 0;

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
        InitializeInventory();
    }

    public void Update()
    {
        // А нет у юнити интерфейсика на event колесикa мышки. Сорри нот сорри гайз, будем работать так.
        if (Input.mouseScrollDelta.y != 0)
        {
            currentItem += (int)Input.mouseScrollDelta.y;

            if (currentItem >= inventoryCapacity)
                currentItem -= inventoryCapacity;

            if (currentItem < 0)
                currentItem = inventoryCapacity + currentItem;

            onCurrentItemChanged?.Invoke(currentItem);
        }
    
    }

    private void InitializeInventory()
    {
        itemsList = new List<Item>(inventoryCapacity);
        allItems = new List<Item>();
        itemsMap = new Dictionary<int, Item>(allItems.Count);

        foreach (Item item in Resources.FindObjectsOfTypeAll(typeof(Item)) as Item[])
        {
            allItems.Add(item);
        }

        foreach (Item item in allItems)
        {
            Debug.LogError(item);
        }

        foreach (var item in allItems)
        {
            itemsMap.Add((int)item.id, item);
        }
        onItemAdd += showInventory.UpdateInventory; //Главное отписаться не забудь 
        onCurrentItemChanged += showInventory.UpdateSlot;
        onCurrentItemChanged?.Invoke(currentItem);
    }

    public void UseItem(Item itemToUse)
    {
        itemToUse.EnableItem();
    }

    public void AddItemToInventory(int id)
    {
        if (itemsList.Count + 1 <= inventoryCapacity)
        {
            itemsList.Add(itemsMap[id]);
            onItemAdd?.Invoke();
        }
        else { Debug.Log("Inventory is full!"); }
    }

    public void AddItemToInventory(Items item)
    {
        if (itemsList.Count + 1 <= inventoryCapacity)
        {
            itemsList.Add(itemsMap[(int)item]);
            onItemAdd?.Invoke();
        }
        else { Debug.Log("Inventory is full!"); }
    }

    public int GetInventoryLength()
    {
        return itemsList.Count;
    }

    public List<Item> GetInventory()
    {
        return itemsList;
    }
}
