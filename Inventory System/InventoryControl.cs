using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityStandardAssets.CrossPlatformInput;
public  class InventoryControl : MonoBehaviour
{
    public bool pressed=false;
    public CanvasGroup inventoryPanel;
    public  int pressCount;
   

   

    void Start()
    {
        inventoryPanel.alpha = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
           // inventoryPanel.alpha = 1;
            //  pressed = true;
            pressCount++;
           /* Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;*/
         
        }
        /*else if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.alpha = 0;
            

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }*/
        if(pressCount == 1)
        {
            inventoryPanel.alpha = 1;

            

           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            
            
        }
        if(pressCount == 2)
        {
            inventoryPanel.alpha = 0;


            
           
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            pressCount = 0;
        }

    }
    IEnumerator Delay(float time)
    {

        yield return new WaitForSeconds(time);
        pressed = true;
        // Code to execute after the delay
    }
}
