using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioClip ammoPickupClip;
    

    [SerializeField] int ammoAmount;

    AudioSource audioSource;
    Ammo ammo;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        ammo = FindObjectOfType<Ammo>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Destroy(gameObject);
            audioSource.PlayOneShot(ammoPickupClip);
            ammo.IncreaseAmmos(ammoType, ammoAmount);
        }
    }
}
