using CharacterMovement;
using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class SlotButtonInventory : MonoBehaviour
{

    [SerializeField] public int buttonIndex;
    [SerializeField] Button button;
    private Items ItemType;
    PlayerInteract playerInteract;
    Items item => playerInteract.slots[buttonIndex];

    private void Start()
    {
        playerInteract = FindAnyObjectByType<MyPlayerController>().GetComponent<PlayerInteract>();
    }

    public void Initialize()
    {
        button.onClick.AddListener(OnClicked);
    }

    public void OnClicked() //click to use the item in the inventory
    {
        Debug.Log("Item Clicked =" + buttonIndex);
        UseItem();
    }
    public void UseItem() //click to use the item in the inventory
    {

        if (item != null ) 
        {
            Debug.Log("Slot not empty");
            //check item type
            Debug.Log("Item used");
        }
        else
        {
            Debug.Log("Slot empty");
        }
    }
}
