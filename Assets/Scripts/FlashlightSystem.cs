using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    Light myLight;


    void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreseLightIntensity();
    }

    private void DecreseLightIntensity()
    {
        if (myLight.intensity >= 0.5f)
        {
            myLight.intensity -= lightDecay * Time.deltaTime;
        }
    }

    public void RestoreIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }
}
