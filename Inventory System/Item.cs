using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string itemName,itemİnfo;
    public int itemId, itemCount,itemStorage,itemDamage;
    public Sprite itemIcon;
    public GameObject itemModel;
    public ItemType itemType;

    public enum ItemType
    {
        weapons,
        material,
        food,
        empty,

    };
   
    public  Item(string name ,string info,int id,int count,int storage,int damage,ItemType type )
    {
        itemName = name;
        itemİnfo = info;
        itemId = id;
        itemCount = count;
        itemStorage = storage;
        itemDamage = damage;
        itemType = type;
        itemIcon = Resources.Load<Sprite>(id.ToString());
        itemModel = Resources.Load<GameObject>(name);

        

    }
    
    public Item()
    {


    }
}
