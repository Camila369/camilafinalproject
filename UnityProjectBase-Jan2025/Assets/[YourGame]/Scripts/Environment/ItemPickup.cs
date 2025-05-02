using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items Item;

    public void Interact()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }
}
