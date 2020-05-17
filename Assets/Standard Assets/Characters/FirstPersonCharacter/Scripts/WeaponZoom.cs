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

    private void OnDisable()
    {
        zoomOut();
    }

    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            zoomIn();
        }
        else
        {
            zoomOut();
        }
    }

    private void zoomOut()
    {
        cameraFPS.fieldOfView = zoomedOutFOV;
        firstPersonController.mouseLook.XSensitivity = zoomedOutSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    private void zoomIn()
    {
        cameraFPS.fieldOfView = zoomedInFOV;
        firstPersonController.mouseLook.XSensitivity = zoomedInSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
    }
}
