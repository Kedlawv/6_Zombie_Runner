using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] int damage = 40;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void attackAnimHitEvent()
    {
        if(target == null) { return; }
        Debug.Log("bang");
        target.takeDamage(damage);
    }

}
