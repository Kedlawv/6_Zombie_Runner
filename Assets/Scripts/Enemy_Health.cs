using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    Animator animator;
    EnemyAI enemyAI;
    bool isDead = false;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        enemyAI = this.GetComponent<EnemyAI>();
    }

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
        animator.SetTrigger("dead");
        isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
