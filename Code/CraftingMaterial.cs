using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMaterial : Item
{

    public string craftingType;

    public CraftingMaterial(string name, string itemType, int ItemID, int slotSpace , string craftingType) : base(name, itemType, ItemID, slotSpace)
    {
        this.craftingType = craftingType;
    }
}
