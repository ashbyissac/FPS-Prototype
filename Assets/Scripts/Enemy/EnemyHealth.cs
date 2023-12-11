using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] bool isAlive = true;
    public bool IsAlive { get { return isAlive; } }

    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DamageEnemy(int hitHealthPoints)
    {
        health -= hitHealthPoints;
        Debug.Log(health);
        if (health < 1 && isAlive)
        {
            animator.SetTrigger("die");
            isAlive = false;
        }

        BroadcastMessage("SetIsProvoked", SendMessageOptions.DontRequireReceiver);
    }
}
