using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    float intensityAmount = 3f;
    FlashlightSystem flashlightSystem;
    void Start()
    {
        flashlightSystem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<FlashlightSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            flashlightSystem.RestoreIntensity(intensityAmount);
            Destroy(this.gameObject);
        }
    }
}
