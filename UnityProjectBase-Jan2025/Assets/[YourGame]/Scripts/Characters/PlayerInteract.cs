using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Rendering;
using TMPro;


public class PlayerInteract : MonoBehaviour
{
    //public Items Item;
    public Items[] slots;
    public Image[] slotImage;
    public int[] slotAmount;
    [SerializeField] private float interactRange = 1f;
    [SerializeField] private TextMeshProUGUI interactext;


    // Update is called once per frame
    private void Update()
    {
        //make a sphere around the player with a range to check what the player is colliding with
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        
            //return what the player has collided with
            foreach (Collider collider in colliderArray)
            {

                
                

                    if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                    {

                        interactext.text = npcInteractable.GetInteractText();
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            npcInteractable.Interact();
                        }

                    }
                    else if (collider.TryGetComponent(out DoorInteractable doorInteractable))
                    {

                        interactext.text = doorInteractable.GetInteractText();

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            doorInteractable.Interact();
                        }

                    }
                    else if (collider.TryGetComponent(out ItemPickup item))
                    {
                        interactext.text = item.GetInteractText();

                        if (Input.GetKeyDown(KeyCode.E))
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

    public PlayerInteract GetInteractableObject()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {

            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return npcInteractable;

            }
            else if (collider.TryGetComponent(out DoorInteractable doorInteractable))
            {
                return doorInteractable;

            }
            else if (collider.TryGetComponent(out ItemPickup item))
            {
                return item;

            }
        }
        return null;


    }



}



