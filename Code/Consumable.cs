using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{

    public int healthPointRestore;
    public int energyRestore;
    public int hungerRestore;

    public Consumable(string name, string itemType, int ItemID, int slotSpace, int healthPointRestore, int energyRestore, int hungerRestore) : base(name, itemType, ItemID, slotSpace)
    {
        this.healthPointRestore = healthPointRestore;
        this.energyRestore = energyRestore;
        this.hungerRestore = hungerRestore;
    }
}
