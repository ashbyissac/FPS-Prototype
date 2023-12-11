using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    [SerializeField] float zoomIn = 30f;
    [SerializeField] float zoomOut = 60f;

    [SerializeField] float zoomedInSensitivity = 0.5f;
    [SerializeField] float zoomedOutSensitivity = 1.5f;

    DeathHandler deathHandler;
    bool isZoomed = false;

    void OnDisable()
    {
        ZoomOutWeapon();   
    }

    void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();    
    }

    void Update()
    {
        ProcessWeaponZoom();
    }

    private void ProcessWeaponZoom()
    {
        if (Input.GetMouseButtonDown(1) && !deathHandler.IsGameOver())
        {
            if (!isZoomed)
            {
                ZoomInWeapon();
            }
            else
            {
                ZoomOutWeapon();
            }
        }
    }

    void ZoomInWeapon()
    {
        fpCamera.fieldOfView = zoomIn;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
        isZoomed = true;
    }

    public void ZoomOutWeapon()
    {
        fpCamera.fieldOfView = zoomOut;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
        isZoomed = false;
    }
}
