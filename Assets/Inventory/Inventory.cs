using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance = null;

    private delegate void OnItemAdd();
    private event OnItemAdd onItemAdd;

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
