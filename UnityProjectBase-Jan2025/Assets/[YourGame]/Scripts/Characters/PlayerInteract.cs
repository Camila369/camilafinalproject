using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Rendering;


public class PlayerInteract : MonoBehaviour
{
    //public Items Item;
    public Items[] slots;
    public Image[] slotImage;
    public int[] slotAmount;


    //private string ObjectTag = "Interactable";

    //private InterfaceController iController;

    //private void Start()

    //iController = Object.FindFirstObjectByType<InterfaceController>();


    // Update is called once per frame
    private void Update()
    {
        float interactRange = 1f;
        //make a sphere around the player with a range of 2 to check what the player is colliding with
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        //return what the player has collided with

            foreach (Collider collider in colliderArray)
            {
                //if (collider.CompareTag(ObjectTag))


                //iController.itemText.text = "Press (E)";

                if (Input.GetKeyDown(KeyCode.E)) //when player presses E to interact
                {

                    if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                    {
                        //iController.itemText.text = "Press (E) to Talk";


                        npcInteractable.Interact();

                    }
                    else if (collider.TryGetComponent(out DoorInteractable doorInteractable))
                    {

                        //iController.itemText.text = "Press (E) to Open";

                        doorInteractable.Interact();

                    }
                    else if (collider.TryGetComponent(out ItemPickup item))
                    {

                        //iController.itemText.text = "Press (E) to Collect" + item.transform.GetComponent<ItemPickup>().ObjectType.name;


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

        
        //else if (!collider.CompareTag(ObjectTag))
        
                //iController.itemText.text = null;
        

    }

    public PlayerInteract GetInteractableObject()
    {
        float interactRange = 1f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {

            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {

                return npcInteractable;
                Debug.Log("return NPC");

            }
            else if (collider.TryGetComponent(out DoorInteractable doorInteractable))
            {
                return doorInteractable;
                Debug.Log("return door");

            }
            else if (collider.TryGetComponent(out ItemPickup item))
            {

                return item;
                Debug.Log("return item");

            }
        }
        return null;
        Debug.Log("return null");


    }



}



