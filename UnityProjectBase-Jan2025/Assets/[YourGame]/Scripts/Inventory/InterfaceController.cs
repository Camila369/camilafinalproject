using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    public GameObject inventoryPanel;
    //public TMP_Text itemText;
    bool invActive;

    private void Start()
    {
        //itemText.text = null;
    }

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
