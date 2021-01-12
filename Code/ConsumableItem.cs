using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : PIckUp
{

    [SerializeField] private string consumableName;
    [SerializeField] private string consumableItemType;
    [SerializeField] private int consumableItemId;
    [SerializeField] private int consumableHealthPointRestore;
    [SerializeField] private int consumableEnergyRestore;
    [SerializeField] private int consumableHungerRestore;

    public override void Start()
    {
        item = new Consumable(name: consumableName, itemType: consumableItemType, ItemID: consumableItemId, slotSpace: 1 , healthPointRestore: consumableHealthPointRestore, energyRestore: consumableEnergyRestore, hungerRestore: consumableHungerRestore);
    }
}
