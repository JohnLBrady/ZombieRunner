using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float minimumLightDecay = 2f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    private void Start() {
        myLight = GetComponent<Light>();
    }

    private void Update() {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLight(float angle, float intensity){
        myLight.spotAngle = angle;
        myLight.intensity = intensity;
    }

    private void DecreaseLightAngle()
    {
        
        if(myLight.spotAngle > minimumAngle){
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        if(myLight.intensity > minimumLightDecay){
            myLight.intensity -= lightDecay * Time.deltaTime;
        }
    }
}
