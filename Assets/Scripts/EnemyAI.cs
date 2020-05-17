using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float rotationSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Renderer enemyRenderer;
    Animator animator;
    

    // Start is called before the first frame update

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyRenderer = this.GetComponent<Renderer>();
        animator = this.GetComponent<Animator>();
        target = FindObjectOfType<PlayerHealth>().GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);
        
        if (isProvoked)
        {
            engageEnemy();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
        }
    }

    public void onDamageTaken()
    {
        isProvoked = true;
    }

    private void engageEnemy()
    {
        faceTarget();

        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            animator.SetBool("attack", false);
            chase();
        }
        else if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            attack();
        }
    }

    private void chase()
    {
        enemyRenderer.material.SetColor("_Color", Color.white);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void attack()
    {
        Debug.Log(this.name + " is attacking " + target.name);
        animator.SetBool("attack", true);
        enemyRenderer.material.SetColor("_Color", Color.red);
    }

    private void faceTarget()
    {
        Vector3 direction = (target.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawWireSphere(this.transform.position, chaseRange);
    }
}
