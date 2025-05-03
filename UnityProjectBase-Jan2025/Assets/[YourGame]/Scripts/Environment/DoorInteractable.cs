using UnityEngine;

public class DoorInteractable : PlayerInteract
{
    [SerializeField] public string interactText = "Open";
    public void Interact()
    {
        Debug.Log("Interact");
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
