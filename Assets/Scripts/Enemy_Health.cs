using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void takeDamage(int amount)
    {
        health -= amount;

        BroadcastMessage("onDamageTaken");

        if(health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
