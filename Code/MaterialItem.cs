using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialItem : PIckUp
{

    [SerializeField] private string materialName;
    [SerializeField] private string materialItemType;
    [SerializeField] private int materialItemID;
    [SerializeField] private string materialCraftingType;

    public override void Start()
    {
        item = new CraftingMaterial(name: materialName, itemType: materialItemType, ItemID: materialItemID, slotSpace: 1 , craftingType: materialCraftingType);
    }

}
