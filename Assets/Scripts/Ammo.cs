using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount;

    public int getCurrentAmmo()
    {
        return ammoAmount;
    }

    public void reduceCurrentAmmo()
    {
        ammoAmount--;
    }
}
