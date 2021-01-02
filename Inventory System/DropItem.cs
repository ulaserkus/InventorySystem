using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour,IPointerDownHandler
{

    Inventory inv;
   public GameObject Hand;

    void Start()
    {

        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
       
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        if (eventData.button.ToString() == "Left"&& inv.carry)
        {


            GameObject p = Instantiate(inv.carryItem.itemModel,Hand.transform.position,Quaternion.identity)as GameObject;

            //Instantiate(p,Hand.transform);


            inv.carryItem.itemCount -= 1;

            if(inv.carryItem.itemCount == 0)
            {
                inv.CarryPanelOff();
            }

        }



    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
