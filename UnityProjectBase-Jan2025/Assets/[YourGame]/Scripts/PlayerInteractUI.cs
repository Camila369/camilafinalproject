using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject InteractContainer;
    [SerializeField] private TextMeshProUGUI interactext;
    [SerializeField] private PlayerInteract playerInteract;


    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show();
            

        }
        else
        {
            Hide();
        }
            
    }


    private void Show()
    {
        InteractContainer.SetActive(true);

    }

    private void Hide()
    {
        InteractContainer.SetActive(false);
    }


}
