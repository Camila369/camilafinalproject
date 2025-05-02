using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Items Item;

    // Update is called once per frame
    void Update()
    { 
    
        if(Input.GetKeyDown(KeyCode.E)) //when player presses E to interact
        {
            float interactRange = 2f;
            //make a sphere around the player with a range of 2 to check what the player is colliding with
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            //return what the player has collided with
            foreach (Collider collider in colliderArray)
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                    npcInteractable.Interact();
            }
            else if (collider.TryGetComponent(out DoorInteractable doorInteractable))
            {
                doorInteractable.Interact();
            }
            else if (collider.TryGetComponent(out ItemController item))
            {
                    item.Interact();
                }


        }

        
    }
}
