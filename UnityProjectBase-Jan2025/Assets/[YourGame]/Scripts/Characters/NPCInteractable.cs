using UnityEngine;

public class NPCInteractable : PlayerInteract
{
    public string NPCname;
    [SerializeField] public string interactText = "Talk";
    public void Interact()
    {
        Debug.Log("Interact");
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
