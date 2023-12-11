using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioClip gunShotSFX;
    [SerializeField] AudioClip emptyGunShotSFX;

    [SerializeField] float range = 100f;
    [SerializeField] float shootDelay = 0.1f;
    [SerializeField] int damageHealth = 10;

    DeathHandler deathHandler;
    WeaponSwitcher weaponSwitcher;
    AudioSource audioSource;
    bool isShoot;

    void OnEnable()
    {
        isShoot = true;    
    }

    void Start()
    {
        audioSource = fpCamera.GetComponent<AudioSource>();
        deathHandler = FindObjectOfType<DeathHandler>();
        weaponSwitcher = GetComponentInParent<WeaponSwitcher>();
    }
    
    void Update()
    {
        if (weaponSwitcher.CurrentWeapon == 2)
        {
            if (Input.GetMouseButton(0) && isShoot && !deathHandler.IsGameOver())
            {
                StartCoroutine(ShootEnemy());
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && isShoot && !deathHandler.IsGameOver())
            {
                StartCoroutine(ShootEnemy());
            }
        }
    }

    
    IEnumerator ShootEnemy()
    {
        isShoot = false;
        if (ammoSlot.GetAmmoAmount(ammoType) > 0)
        {
            PlaySFX(gunShotSFX);
            ammoSlot.DecreaseAmmos(ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
        }        
        else
        {
            PlaySFX(emptyGunShotSFX);
        }
        yield return new WaitForSeconds(shootDelay);
        isShoot = true;
    }

    void PlaySFX(AudioClip gunShotSFX)
    {
        audioSource.PlayOneShot(gunShotSFX);
    }

    void PlayMuzzleFlash()
    {
        muzzleFlashVFX.Play();
    }

    void ProcessRaycast()
    {   
        RaycastHit hit;
        Vector3 start = fpCamera.transform.position;
        Vector3 direction = fpCamera.transform.forward;

        if (Physics.Raycast(start, direction, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.DamageEnemy(damageHealth);
            }
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject tempHitVFX = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(tempHitVFX, 0.1f);
    }
}
