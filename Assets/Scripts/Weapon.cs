using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 25;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(shoot());
        }
    }

    IEnumerator shoot()
    {
        canShoot = false;

        if (ammoSlot.getCurrentAmmo(this.ammoType) > 0)
        {
            playMuzzleFlash();
            processRaycast();
            ammoSlot.reduceCurrentAmmo(this.ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        
        canShoot = true;
    }

    private void playMuzzleFlash()
    {
        muzzleFlashVFX.Play();
    }

    private void processRaycast()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        if (isHit)
        {
            createHitImpact(hit);
            Enemy_Health target = hit.transform.GetComponent<Enemy_Health>();
            if (target == null) { return; }
            target.takeDamage(damage);
            Debug.Log(hit.collider.name);
            isHit = false;
        }
    }

    private void createHitImpact(RaycastHit hit)
    {
        GameObject tempHitEffect = Instantiate<GameObject>(hitEffect, hit.point, Quaternion.identity);
       
           Destroy(tempHitEffect, 0.2F);
        
    }
}
