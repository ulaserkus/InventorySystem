using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> Items;
    public GameObject slot,infoPanel,CarryPanel;
    public int startCount,slotCount;
    DataItem dataItem;
    public bool infoActive,carry;
    public Item infoItem,carryItem;

    private void Start()
    {
        dataItem = GameObject.FindGameObjectWithTag("DataItem").GetComponent<DataItem>();

        for(int i = startCount; i < slotCount; i++)
        {
            GameObject slotobj = (GameObject)Instantiate(slot);
            slotobj.transform.SetParent(gameObject.transform);
            slotobj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            slotobj.GetComponent<InventorySlot>().slotnumber = i;
          
        }
        for(int i = 0; i < slotCount; i++)
        {
            Items.Add(new Item());
        }

    }



    public void AddItem(int id,int count)
    {
        for(int i = 0; i < dataItem.ıtems.Count; i++)
        {
            if (dataItem.ıtems[i].itemId == id)
            {
                Item newItem = new Item(dataItem.ıtems[i].itemName, dataItem.ıtems[i].itemİnfo, dataItem.ıtems[i].itemId,
                   count, dataItem.ıtems[i].itemStorage, dataItem.ıtems[i].itemDamage,dataItem.ıtems[i].itemType);

                if(newItem.itemType == Item.ItemType.material|| newItem.itemType == Item.ItemType.food)
                {
                    SameItem(newItem);
                }
                else if(newItem.itemCount > 1)
                {
                    int value = newItem.itemCount - 1;
                    Item newItem2 = new Item(newItem.itemName, newItem.itemİnfo, newItem.itemId,
                   value, newItem.itemStorage, newItem.itemDamage, newItem.itemType);
                    newItem.itemCount = 1;
                    checkEmptySlot(newItem);
                    AddItem(newItem2.itemId, newItem2.itemCount);
                }
                else
                {
                    checkEmptySlot(newItem);
                }
               
                    
            }
        }

    }

    public void SameItem(Item item)
    {
        for(int i =0; i < Items.Count; i++)
        {
            if(Items[i].itemName == item.itemName)
            {
                Items[i].itemCount += item.itemCount;
                break;
            }
            if(i == Items.Count - 1)
            {
                checkEmptySlot(item);
            }
        }

    }

    public void checkEmptySlot(Item ıtem)
    {
        for(int i=0;i < Items.Count; i++){
            if (Items[i].itemName == null)
            {
                Items[i] = ıtem;
                break;
            }
        }

    }
    public void infoPanelOpen(Item item)
    {
        infoPanel.SetActive(true);
        infoActive = true;
        infoItem = item;

    }
 
    public void infoPanelOff()
    {
        infoPanel.SetActive(false);
        infoActive = false;
        infoItem = null;
    }

    public void CarryPanelOpen(Item item)
    {
        CarryPanel.SetActive(true);
        carry = true;
        carryItem = item;

    }

    public void CarryPanelOff()
    {
        CarryPanel.SetActive(false);
        carry = false;
        carryItem = null;
    }

    
    private void Update()
    {
        if (infoActive)
        {
            
            infoPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = infoItem.itemName;
            infoPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = infoItem.itemİnfo;
        }

        if (carry)
        {
            CarryPanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = carryItem.itemIcon;
            CarryPanel.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (carryItem.itemCount > 1)
            {
                CarryPanel.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = true;
                CarryPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = carryItem.itemCount.ToString();
            }
            else
            {
                CarryPanel.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = false;
            }
        }
    
     
       
    }
}
