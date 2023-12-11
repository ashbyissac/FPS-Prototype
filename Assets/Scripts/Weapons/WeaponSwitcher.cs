using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    public int CurrentWeapon { get { return currentWeapon; } }

    DeathHandler deathHandler;

    void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    void Update()
    {
        if (!deathHandler.IsGameOver())
        {
            ProcessScrollWheelInput();
            ProcessKeyboardInput();
            SetActiveWeapon();
        }
    }

    void ProcessScrollWheelInput()
    {
        int scrollWheelValue = (int)(Input.GetAxis("Mouse ScrollWheel") * 10); // up = 1 || down = -1 || idle = 0
        currentWeapon += -(scrollWheelValue); 

        if (currentWeapon > transform.childCount - 1)
        {
            currentWeapon = 0;
        }
        else if (currentWeapon < 0)
        {
            currentWeapon = transform.childCount - 1;
        }
    }

    void ProcessKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    
    void SetActiveWeapon()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
