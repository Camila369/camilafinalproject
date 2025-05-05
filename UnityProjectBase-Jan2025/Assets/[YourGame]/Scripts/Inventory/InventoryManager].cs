using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Items> Items = new List<Items>();
    [SerializeField] private GameObject InventoryCanvas;

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Items item)
    {
        Items.Add(item);
    }

    public void Remove(Items item)
    {
        Items.Remove(item);
        Destroy(gameObject);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I)) //when player presses I 
        {
            
            //check if inventory is open
            if (InventoryCanvas.activeInHierarchy == false)
            {
                InventoryCanvas.SetActive(true);
                ListItems();
                //open inventory
                Cursor.lockState = CursorLockMode.None;
            }
            else if (InventoryCanvas.activeInHierarchy == true)
            {
                //close inventory
                InventoryCanvas.SetActive(false);
            }

        }
    }

    public void ListItems()
    {

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("icon").GetComponent<Image>();

            itemName.text = item.ItemName;
            itemIcon.sprite = item.icon;

        }
        
    }
}

