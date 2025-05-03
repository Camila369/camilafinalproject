using UnityEngine;

public class ItemPickup : PlayerInteract
{
    //public Items Item;
    public Items ObjectType;
    public void Interact()
    {
        InventoryManager.Instance.Add(ObjectType);
        Destroy(gameObject);

    }
}
