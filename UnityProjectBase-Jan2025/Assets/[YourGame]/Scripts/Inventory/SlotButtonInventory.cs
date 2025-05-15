using CharacterMovement;
using System;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class SlotButtonInventory : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] public int buttonIndex;
    [SerializeField] Button button;
    [Header("Item Description")]
    [SerializeField] GameObject ItemDescriptionPanel;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemName;
    [Header("Item Use")]
    [SerializeField] GameObject ItemUsePanel;
    [SerializeField] private TextMeshProUGUI itemUse;
    [SerializeField] private TextMeshProUGUI itemDrop;
    [Header("Control")]
    private Items ItemType;
    PlayerInteract playerInteract;
    InterfaceController controller;
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

            if (item.Itemtype == Items.ItemType.Food) // needs the name
            {
                itemName.text = item.ItemName;
                itemDescription.text = "This food looks yummy!";
                itemUse.text = "Eat";
                itemDrop.text = "Drop";
                Debug.Log("Show food information");
                ItemUsePanel.SetActive(true);
                ItemDescriptionPanel.SetActive(true);
            }
            else if (item.Itemtype == Items.ItemType.Weapon)
            {
                itemName.text = item.ItemName;
                itemDescription.text = "Weapons can be used to attack";
                itemUse.text = "Equip";
                itemDrop.text = "Drop";
                Debug.Log("Show weapon information");
                ItemUsePanel.SetActive(true);
                ItemDescriptionPanel.SetActive(true);
            }
            else if (item.Itemtype == Items.ItemType.Ammunition)
            {
                itemName.text = item.ItemName;
                itemDescription.text = "Show ammunition information";
                itemUse.text = "Reload";
                itemDrop.text = "Drop";
                Debug.Log("Show ammunition information");
                ItemUsePanel.SetActive(true);
                ItemDescriptionPanel.SetActive(true);
            }
            else if (item.Itemtype == Items.ItemType.Water) 
            {
                itemName.text = item.ItemName;
                itemDescription.text = "Show water information";
                itemUse.text = "Drink";
                itemDrop.text = "Drop";
                Debug.Log("Show water information");
                ItemUsePanel.SetActive(true);
                ItemDescriptionPanel.SetActive(true);
            }
            else if (item.Itemtype == Items.ItemType.Key) // needs the name
            {
                itemDescription.text = "Show key information";
                itemName.text = item.ItemName;
                Debug.Log("Show key information");
                ItemUsePanel.SetActive(false); // Can`t use inside inventory
                ItemDescriptionPanel.SetActive(true);
            }
            else if (item.Itemtype == Items.ItemType.Clue) // needs the name
            {
                itemName.text = item.ItemName;
                itemDescription.text = "Show clue information";
                Debug.Log("Show clue information");
                ItemUsePanel.SetActive(false); // Can`t use!
                ItemDescriptionPanel.SetActive(true);
            }



        }
        else
        {
            Debug.Log("Slot empty");
        }
    }
}
