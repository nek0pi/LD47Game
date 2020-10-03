using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemSlot> itemSlots;

    public void UpdateInventory()
    {
        var items = Inventory.instance.GetInventory();
        for (int index = 0; index < items.Count; index++)
        {
            Debug.Log(itemSlots[index].gameObject.name + " name " + itemSlots[index].GetComponentsInChildren<Image>()[1].gameObject.name + " another name");
            itemSlots[index].GetComponentsInChildren<Image>()[1].sprite = items[index].icon;    
            //Спасибо юнити за то, что не перегрузили ОДИН МЕТОД, чтобы все коммУнити придумывало велосипед. От души. Завтра надо нормально оформить!

        }
    }
}
