using UnityEngine;

public class ItemPickup : PlayerInteract
{
    [SerializeField] private string interactText = "Collect";
    public Items ObjectType;

    public string GetInteractText()
    {
        return interactText;
    }

}
