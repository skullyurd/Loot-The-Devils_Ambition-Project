using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    public Transform UIItemPrefab;

    private List<PIckUp> uiItems;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        uiItems = new List<PIckUp>();
    }

    public void AddUIItem(PIckUp p)
    {
        if (!uiItems.Contains(p))
        {
            Transform t = Instantiate(UIItemPrefab, transform);
            InventoryUIItem i = t.GetComponent<InventoryUIItem>();
            if (i != null)
            {
                i.registerPickUp(p.item.name, p.InventoryIcon);
                uiItems.Add(p);
            }
        }

    }

    public void RemoveUIItem(string name)
    {

        for (int i = 0; i < uiItems.Count; i++)
        {
            PIckUp p = uiItems[i];
            if (p.item.name == name)
            {
                uiItems.Remove(p);
                Inventory.instance.RemoveItem(p.item);
                break;
            }
        }
    }
    public void useItemInventory(string itemName, InventoryUIItem UIITem)
    {
        for (int i = 0; i < uiItems.Count; i++)
        {
            PIckUp p = uiItems[i];
            if (p.item.name == itemName)
            {
                InventoryUIItem inventoryUI = UIITem;

                Inventory.instance.useItem(p.item, p.item.name, inventoryUI);
                break;
            }
        }
    }

}
