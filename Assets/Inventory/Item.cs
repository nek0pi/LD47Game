using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public Items id;
    public Sprite icon;
    public string objectName;
    public string description;

    public virtual void EnableItem()
    {
        Debug.Log("Base enable object");
    }
}

public enum Items : int
{ 
    Bucket = 0, BucketWithWater, Torch, MagicWand
}
