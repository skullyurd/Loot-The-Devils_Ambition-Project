using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public string name;
    public string itemType;

    public int itemID;
    public int slotSpace;

    public Item(string name, string itemType, int ItemID, int slotSpace)
    {
        this.name = name;
        this.itemType = itemType;

        this.itemID = ItemID;
        this.slotSpace = slotSpace;
    }

}