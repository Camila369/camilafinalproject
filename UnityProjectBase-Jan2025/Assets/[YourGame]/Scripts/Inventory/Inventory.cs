using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    GameObject InventoryCanvas;
    public GameObject mouseItem;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I)) //when player presses I 
        {
           //check if inventory is open
           if (InventoryCanvas.activeInHierarchy == false)
           {
                //open inventory
                InventoryCanvas.SetActive(true); 
           }
           else if (InventoryCanvas.activeInHierarchy == true)
           {
                //close inventory
                InventoryCanvas.SetActive(false); 
           }
        
        }

    }

    public void DragItem( GameObject button)
    {

    }

    public void DropItem( GameObject button )
    {


    }
}
