using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    public class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void IncreaseAmmos(AmmoType ammoType, int pickupAmmoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += pickupAmmoAmount;
    }

    public void DecreaseAmmos(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
