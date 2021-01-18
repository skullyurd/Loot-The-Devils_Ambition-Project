using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponItem : PIckUp
{

    [SerializeField]   string  weaponName;
        [SerializeField] string weaponItemType;
    [SerializeField]     private int weaponItemID;
    [SerializeField]     private int weaponStrengthNeeded;
    [SerializeField]     private int weaponDexterityNeeded;
    [SerializeField]     string weaponEquipmentType;
    [SerializeField]     private int weaponAddedAttackPower;

    public override void Start()
    {
        item = new Weapon(name: weaponName, itemType: weaponItemType, ItemID: weaponItemID, slotSpace: 1 ,strengthNeeded: weaponStrengthNeeded, dexterityNeeded: weaponDexterityNeeded, equipmentType: weaponEquipmentType, addedAttackPower: weaponAddedAttackPower);
    }

    public void Skillcheck()
    {

    }

    
}
