using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int hitEffect = 10;

    PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void EnemyHitEvent()
    {
        if (playerHealth == null) { return; }
        playerHealth.DamagePlayer(hitEffect);
    }
}
