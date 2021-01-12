using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{

    public int addedArmorRating;
    public int dodgePenalty;

    public Armor(string name, string itemType, int ItemID, int slotSpace ,int strengthNeeded, int dexterityNeeded, string equipmentType, int addedArmorRating, int dodgePenalty) : base(name, itemType, ItemID, slotSpace ,strengthNeeded, dexterityNeeded, equipmentType)
    {
        this.addedArmorRating = addedArmorRating;
        this.dodgePenalty = dodgePenalty;
    }
}
