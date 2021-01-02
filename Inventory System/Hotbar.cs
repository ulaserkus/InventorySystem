using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public List<GameObject> Slots;
    public int slotNumber;
    public Sprite chosenSlot,emptySlot;
    Inventory inv;
    Hand hand;
    private void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>();
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void Update()
    {
        SelectIcon();
        FindSlotNumber();
        SelectItem(inv.Items[slotNumber]);
    }

    void FindSlotNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotNumber = 0;

        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotNumber = 1;

        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotNumber = 2;

        }
       else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotNumber = 3;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotNumber = 4;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            slotNumber = 5;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            slotNumber = 6;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            slotNumber = 7;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            slotNumber = 8;

        }

    }

    void SelectIcon()
    {

        for(int i = 0; i < Slots.Count; i++)
        {
            Slots[i].GetComponent<Image>().sprite = emptySlot;

        }
        Slots[slotNumber].GetComponent<Image>().sprite = chosenSlot;

    }

    void SelectItem(Item item)
    {

        for(int i = 0; i < hand.objects.Count; i++)
        {
            if(hand.objects[i].name == item.itemName)
            {
                hand.objects[i].SetActive(true);
            }
            else
            {
                hand.objects[i].SetActive(false);
            }
        }
    }
}
