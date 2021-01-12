using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{

    public int addedAttackPower;

    public Weapon(string name, string itemType, int ItemID, int slotSpace ,int strengthNeeded, int dexterityNeeded, string equipmentType, int addedAttackPower) : base(name, itemType, ItemID, slotSpace ,strengthNeeded, dexterityNeeded, equipmentType)
    {
        this.addedAttackPower = addedAttackPower;
    }
}
