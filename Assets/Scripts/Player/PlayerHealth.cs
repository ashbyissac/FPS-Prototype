using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void DamagePlayer(int hitEffect)
    {
        health -= hitEffect;
        if (health < 1)
        {
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("GAME OVER");
        }
    }
}
