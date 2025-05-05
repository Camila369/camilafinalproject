using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class SlotButtonInventory : MonoBehaviour
{
    private PlayerInteract playerInteract;
    [SerializeField] public int buttonIndex;
    [SerializeField] Button button;
    private Items ItemType;

    public void Initialize()
    {
        button.onClick.AddListener(OnClicked);
    }

    public void OnClicked() //click to use the item in the inventory
    {
        //playerInteract.ItemClicked(button, buttonIndex);
        //playerInteract.UseItemAtIndex(buttonIndex);
        Debug.Log("Item Clicked =" + buttonIndex);
        UseItem();
    }
    public void UseItem() //click to use the item in the inventory
    {
        Items item = GetComponent<PlayerInteract>().slots[buttonIndex];

        if (item != null ) 
        {
            Debug.Log("Slot not empty");
            //check item type
            Debug.Log("Item used");
        }
    }
}
