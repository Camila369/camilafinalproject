using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Items> items = new List<Items>();
    [SerializeField] private GameObject InventoryCanvas;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Items item)
    {
        items.Add(item);
    }

    public void Remove(Items item)
    {
        items.Remove(item);
    }

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
}
