using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] int normalFOV = 60;
    [SerializeField] int zoomFOV = 20;
    [SerializeField] float normalMouseSpeed = 5;
    [SerializeField] float zoomedMouseSpeed = 1;

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] FirstPersonController fpsController;

    bool zoomedInToggle = false;

    private void OnDisable() {
        ZoomOut();
    }

    public void OnZoom(){
        if(zoomedInToggle == false)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        virtualCamera.m_Lens.FieldOfView = zoomFOV;
        fpsController.RotationSpeed = zoomedMouseSpeed;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        virtualCamera.m_Lens.FieldOfView = normalFOV;
        fpsController.RotationSpeed = normalMouseSpeed;
    }
}
