using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemController : MonoBehaviour
{
    public Items Item;
    public void Interact()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

}
