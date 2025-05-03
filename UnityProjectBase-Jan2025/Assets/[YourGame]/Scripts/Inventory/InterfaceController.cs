using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    public GameObject inventoryPanel;
    bool invActive;

    // open inventory
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) //when player presses I 
        {

            invActive =! invActive;
            inventoryPanel.SetActive(invActive);

        }
        if (invActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    
}
