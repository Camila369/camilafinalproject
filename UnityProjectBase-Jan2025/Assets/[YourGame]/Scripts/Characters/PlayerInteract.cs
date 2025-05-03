using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class PlayerInteract : MonoBehaviour
{
    //public Items Item;
    public Items[] slots;
    public Image[] slotImage;
    public int[] slotAmount;

    private InterfaceController iController;

    private void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
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
            else if (collider.TryGetComponent(out ItemPickup item))
            {


                    for (int i = 0; i < slots.Length; i++)
                    {
                        //verify if item is on the inventory
                        if (slots[i] == null || slots[i].name == item.transform.GetComponent<ItemPickup>().ObjectType.name)
                        {
                            slots[i] = item.transform.GetComponent<ItemPickup>().ObjectType;
                            slotAmount[i]++;
                            slotImage[i].sprite = slots[i].icon;
                            Destroy(item.transform.gameObject);
                            break; // stop the loop

                        }

                    }
                


            }


        }

        
    }


}
