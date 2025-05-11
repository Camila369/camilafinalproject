using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Rendering;
using TMPro;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using System;
using UnityEditor.PackageManager.UI;


public class PlayerInteract : MonoBehaviour
{
    //public Items Item;
    public Items[] slots = new Items[12];
    public Image[] slotImage;
    public Button[] slotButton;
    public int[] slotAmount;
    [SerializeField] private float interactRange = 1f;
    [SerializeField] private TextMeshProUGUI interactext;
    private Items items;
    bool hasClicked = false;
    bool slotFull = false;
    SlotButtonInventory slotinventory;

    // Update is called once per frame
    private void Update()
    {
        //make a sphere around the player with a range to check what the player is colliding with
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        //return what the player has collided with
        foreach (Collider collider in colliderArray)
        {

            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {

                interactext.text = npcInteractable.GetInteractText();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    npcInteractable.Interact();
                }

            }
            else if (collider.TryGetComponent(out DoorInteractable doorInteractable))
            {

                interactext.text = doorInteractable.GetInteractText();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    doorInteractable.Interact();
                }

            }
            else if (collider.TryGetComponent(out ItemPickup item))
            {
                interactext.text = item.GetInteractText();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    

                    for (int i = 0; i < slots.Length; i++)
                    {
                        //verify if item is already on the inventory
                        if (slots[i] == null || slots[i].name == item.transform.GetComponent<ItemPickup>().ObjectType.name)
                        {
                            slots[i] = item.transform.GetComponent<ItemPickup>().ObjectType;
                            slotAmount[i]++;
                            slotImage[i].sprite = slots[i].icon;
                            Destroy(item.transform.gameObject);
                            break; // stop the loop

                        }

                    }
                }

            }

        }



    }

    public PlayerInteract GetInteractableObject()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {

            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return npcInteractable;

            }
            else if (collider.TryGetComponent(out DoorInteractable doorInteractable))
            {
                return doorInteractable;

            }
            else if (collider.TryGetComponent(out ItemPickup item))
            {
                return item;

            }
        }
        return null;


    }

    //public int OnClicked(Button button) //click to use the item in the inventory
    //{
    //    int buttonIndex;
    //    // get the button index
    //    buttonIndex = Array.IndexOf(slotButton, button);

    //    hasClicked = true;

    //    SelectItem();

    //    return buttonIndex;
    //}

    //public void CompareArrays(Items itemClicked, Button button, bool HasItem)
    //{

    //    Debug.Log("CompareArrays");

    //    int slotIndex = Array.IndexOf(slots, itemClicked);
    //    slotIndex = OnClicked(button);

    //    if (itemClicked != null) // if the button index has an item
    //    {
    //        HasItem = true;
    //        Debug.Log("Has Item");
    //        slotFull = HasItem;

    //    }
    //    else if (itemClicked == null) // if the button index doesn't have an item
    //    {
    //        Debug.Log("Is empty");
    //        HasItem = false;
    //        slotButton[slotIndex + 1].interactable = false;
    //        slotFull = HasItem;
    //    }

    //}

    //public void ItemClicked(Button button, int buttonIndex)
    //{
    //    buttonIndex = Array.IndexOf(slotButton, button);
    //    int slotIndex = slotinventory.buttonIndex;
    //    slotIndex = Array.IndexOf(slots, slots[slotIndex]);

    //    if (slots[slotIndex] != null) // if the button index has an item
    //    {
    //        slotFull = true;
    //        Debug.Log("Has Item");
    //        //check which item it is
    //        //change the text of the buttons according to the item
    //        //open screen
    //        //change use item button
    //        //allow to delete item or not

    //    }
    //    else if (slots[slotIndex] == null) // if the button index doesn't have an item
    //    {
    //        Debug.Log("Is empty");
    //        slotFull = false;
    //        slotButton[slotIndex + 1].interactable = false;
            
    //    }
    //}

    //public void UseItemAtIndex(int index)
    //{
    //    if (index >= 0 && index < slotAmount[12])
    //    {
    //        slotButton[index].interactable = true;
    //        Debug.Log("Use Button");
    //        //slots[index].Use();
    //    }
    //    else
    //    {
    //        slotButton[index].interactable = false;
    //        Debug.LogWarning("Invalid inventory index");
    //    }
    //}

    //private void SelectItem()
    //{
    //    Debug.Log("Select Item");

    //    if (slotFull == true)
    //    {
    //        //check which item it is
    //        //change the text of the buttons according to the item
    //        //open screen
    //        Debug.Log("Use Item");
    //        slotFull = false;
    //        //change use item button
    //        //allow to delete item or not

    //    }
    //    else if (!slotFull) 
    //    {
    //        Debug.Log("Don't open");
    //    }

        
    //}



}



