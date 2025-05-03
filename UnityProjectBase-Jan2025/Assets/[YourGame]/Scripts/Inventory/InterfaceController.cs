using UnityEngine;

public class InterfaceController : MonoBehaviour
{

    public GameObject inventoryPanel;
    bool invActive;

    // Update is called once per frame
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
