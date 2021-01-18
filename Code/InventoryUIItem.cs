using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIItem : MonoBehaviour
{
    public static InventoryUIItem instance;

    public Image itemImage;
    public TextMeshProUGUI itemName;

    private void Awake()
    {
        instance = this;
    }

    public void registerPickUp(string name, Sprite icon)
    {
        itemImage.sprite = icon;
        itemName.text = name;
        this.name = name;
    }

    public void HandleClick()
    {
        GameObject targetName = GameObject.Find(itemName.text);
        InventoryUI.instance.RemoveUIItem(itemName.text);
        Destroy(targetName);
    }

    public void useItem()
    {
        GameObject targetName = GameObject.Find(itemName.text);



        if (Player.instance.isInBase == true)
        {
            Debug.Log("move to base");

            if (transform.parent.gameObject.name == "inventoryPanel_Base")
            {
                InventoryUIBase.instance.identifyItem(itemName.text);

                InventoryUIBase.instance.RemoveUIItem(itemName.text);
                Destroy(targetName);
                return;
            }
            if (transform.parent.gameObject.name == "inventory_panel")
            {
                
                InventoryUI.instance.identifyItem(itemName.text);

                InventoryUI.instance.RemoveUIItem(itemName.text);
                Destroy(targetName);
                return;
            }





            

        }

        if (Player.instance.isInBase == false)
        {
            InventoryUI.instance.useItemInventory(itemName.text);

        }
    }
}
