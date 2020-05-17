using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int getCurrentAmmo(AmmoType ammoType)
    {
        return getAmmoSlot(ammoType).ammoAmount;
    }

    public void reduceCurrentAmmo(AmmoType ammoType)
    {
        getAmmoSlot(ammoType).ammoAmount--;
    }

    private AmmoSlot getAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in this.ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}
