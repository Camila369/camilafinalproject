using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    // click solo in the cinemachine
    // and control + shift + f to aling the camera to where you want

    //public CinemachineCamera activeCamera;
    [field: Header("Camera")]
    [SerializeField] private GameObject activeCamera;
    [SerializeField] private GameObject lastCamera;

    [field: Header("Player")]
    //[SerializeField] private Transform PlayerPosition;
    [SerializeField] private GameObject Player;

    public string currentCameraTag = "MainCamera";
    public string CameraDisabledTag = "CameraDisabled";

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (activeCamera.activeInHierarchy == false)
            {
                //diable last camera
                    //disable camera
                    lastCamera.SetActive(false);

                    //change tag
                    lastCamera.tag = CameraDisabledTag;

                // now activate new camera
                    //set to active
                    activeCamera.SetActive(true);

                    //change tag
                    activeCamera.tag = currentCameraTag;

            }
            else if (activeCamera.activeInHierarchy == true)
            {
                //diable active camera
                activeCamera.SetActive(false);

                //change activecamera tag
                activeCamera.tag = CameraDisabledTag;

                // now last new camera:
                //set to active
                lastCamera.SetActive(true);

                //change tag
                lastCamera.tag = currentCameraTag;


            }



        }

    }
}
