using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{ 
    [SerializeField] int damage = 40;
    PlayerHealth target;
    

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void attackAnimHitEvent()
    {
        if(target == null) { return; }
        target.GetComponent<DisplayDamage>().ShowDamageCanvas();
        target.takeDamage(damage);
    }

}
