using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;



public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cameraFPS;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutSensitivity = 2.0f;
    [SerializeField] float zoomedInSensitivity = 0.5f;

    

    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cameraFPS.fieldOfView = zoomedInFOV;
            firstPersonController.mouseLook.XSensitivity = zoomedInSensitivity;
            firstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
        }
        else
        {
            cameraFPS.fieldOfView = zoomedOutFOV;
            firstPersonController.mouseLook.XSensitivity = zoomedOutSensitivity;
            firstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
        }
    }

}
