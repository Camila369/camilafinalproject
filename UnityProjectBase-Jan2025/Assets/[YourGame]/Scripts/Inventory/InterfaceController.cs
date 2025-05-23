using CharacterMovement;
using TMPro;
using UIComponents;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : CharacterMovementBase
{

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private GameObject ItemDescriptionPanel;
    [SerializeField] private GameObject ItemUsePanel;
    public bool invActive;
    private bool isOpen;
    private PlayerInteract playerInteract;
    //CharacterMovement3D turn = new CharacterMovement3D();

    // open inventory
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) //when player presses I 
        {

            invActive =! invActive;
            if (!isOpen) //open the inventory
            {
                Time.timeScale = 0f; //pause time
                isOpen = true;
                //CanTurn = false;
            }
            else if (isOpen) // close the inventory
            {
                Time.timeScale = 1f;
                isOpen = false;
                //CanTurn = true;
                ItemDescriptionPanel.SetActive(false);
                ItemUsePanel.SetActive(false);
            }
            
            inventoryMenu.SetActive(invActive);
            inventoryPanel.SetActive(invActive);

        }
        if (invActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }


    }


}
