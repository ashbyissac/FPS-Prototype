using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f; 

    NavMeshAgent navMeshAgent;
    Animator animator;
    EnemyHealth enemyHealth;

    bool isProvoked = false;
    float targetDistance;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (!enemyHealth.IsAlive)
        {
            this.enabled = false;
            navMeshAgent.enabled = false;
        }

        targetDistance = Vector3.Distance(transform.position, target.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (targetDistance < chaseRange)
        {
            isProvoked = true;
        }
    }

    public void SetIsProvoked()
    {
        Debug.Log("Is provoked in " + this);
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();
        if (targetDistance > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        animator.SetBool("attack", true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }
}
