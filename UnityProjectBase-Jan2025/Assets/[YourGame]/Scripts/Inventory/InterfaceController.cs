using TMPro;
using UIComponents;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    [SerializeField] private GameObject inventoryPanel;
    public bool invActive;
    private bool isOpen;
    private PlayerInteract playerInteract;

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
            }
            else if (isOpen)
            {
                Time.timeScale = 1f;
                isOpen = false;
            }
            
            inventoryPanel.SetActive(invActive);


        }
        if (invActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }


}
