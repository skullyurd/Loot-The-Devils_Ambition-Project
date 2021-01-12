using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorItem : PIckUp
{
   [SerializeField] private string armorItemName;
   [SerializeField] private string armorItemType;
   [SerializeField] private int armorItemID;
   [SerializeField] private int armorStrengthNeeded;
   [SerializeField] private int armorDexterityNeeded;
   [SerializeField] private string armorEquipmentType;
   [SerializeField] private int armorAddedArmorReting;
   [SerializeField] private int armorDodgePenalty;

    public override void Start()
    {
        item = new Armor(name: armorItemName, itemType: armorItemType, ItemID: armorItemID, slotSpace: 1 ,strengthNeeded: armorStrengthNeeded, dexterityNeeded: armorDexterityNeeded, equipmentType: armorEquipmentType, addedArmorRating: armorAddedArmorReting, dodgePenalty: armorDodgePenalty);
    }
}
