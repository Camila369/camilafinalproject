using UnityEngine;
using Unity.Cinemachine;
using FMOD;

public class FixedCamera : MonoBehaviour
{
    // click solo in the cinemachine
    // and control + shift + f to aling the camera to where you want

    //public CinemachineCamera activeCamera;
    [field: Header("Camera")]
    [SerializeField] private GameObject activeCamera;
    [SerializeField] private GameObject lastCamera;

    [field: Header("Player")]
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private GameObject Player;

    public string currentCameraTag = "MainCamera";
    public string CameraDisabledTag = "CameraDisabled";

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //set to active
            activeCamera.SetActive(true);

            //change tag
            activeCamera.tag = currentCameraTag;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //diable last camera

                //disable camera
                lastCamera.SetActive(false);

                //change tag
                lastCamera.tag = CameraDisabledTag;

            // now activate this camera

                //set to active
                activeCamera.SetActive(true);

                //change tag
                activeCamera.tag = currentCameraTag;
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //disable camera
        activeCamera.SetActive(false);

        //change tag
        activeCamera.tag = CameraDisabledTag;
    }

}
