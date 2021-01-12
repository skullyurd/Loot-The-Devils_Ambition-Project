using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    public int strengthNeeded;
    public int dexterityNeeded;

    public string equipmentType;

    public Equipment(string name, string itemType, int ItemID, int slotSpace ,int strengthNeeded, int dexterityNeeded, string equipmentType) : base(name,itemType,ItemID, slotSpace)
    {
        this.strengthNeeded = strengthNeeded;
        this.dexterityNeeded = dexterityNeeded;
        this.equipmentType = equipmentType;
    }
}
