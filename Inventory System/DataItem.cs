using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItem : MonoBehaviour
{
    public List<Item> ıtems;


    private void Awake()
    {
        ıtems.Add(new Item("", "", 0, 0, 0, 0, Item.ItemType.empty));
        ıtems.Add(new Item("Bush", "Crafting Material", 1, 1, 6, 0, Item.ItemType.material));


    }
}    
