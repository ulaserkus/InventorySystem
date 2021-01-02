using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    public int slotnumber;
    public Item item;
    Inventory inv;
    public Image itemIcon;
    public Text itemCount;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();


    }

    private void Update()
    {
        item = inv.Items[slotnumber];
        if(item.itemName != null)
        {
            itemIcon.enabled = true;
            itemIcon.sprite = item.itemIcon;
            
            if (item.itemCount > 1)
            {
                itemCount.enabled = true;
                itemCount.text = item.itemCount.ToString();
            }
            else
            {
                itemCount.enabled = false;
            }

        }
        else
        {
            itemIcon.enabled = false;
            itemCount.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item.itemName != null)
        {
            inv.infoPanelOpen(item);
        }
       
    }
    

    public void OnPointerExit(PointerEventData eventData)
    {
       
            inv.infoPanelOff();
        
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button.ToString() == "Right")
        {
            if (!inv.carry)
            {
                if (item.itemType == Item.ItemType.food || item.itemType == Item.ItemType.material)
                {
                    if (item.itemCount > 1)
                    {
                        int value = item.itemCount/2;

                        Item newItem = new Item(item.itemName, item.itemİnfo, item.itemId,value, item.itemStorage, item.itemDamage, item.itemType);
                        
                        int value2 = item.itemCount - value;
                        inv.Items[slotnumber].itemCount = value2;
                        inv.CarryPanelOpen(newItem);
                    }
                }
            }
        }


        if (eventData.button.ToString() == "Left")
        {
            if (item.itemName != null && !inv.carry)
            {
                inv.CarryPanelOpen(item);
                inv.Items[slotnumber] = new Item();
            }
            else if (inv.carry)
            {
                inv.Items[slotnumber] = inv.carryItem;
                inv.CarryPanelOff();
            }

        }

    }

}
