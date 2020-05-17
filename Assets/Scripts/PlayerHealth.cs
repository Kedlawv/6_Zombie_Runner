using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 90;

    public void takeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Debug.Log("You died");
            die();
        }

       
    }

    public void die()
    {
        GetComponent<DeathHandler>().handleDeath();
    }
}
