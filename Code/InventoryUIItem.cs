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
        Debug.Log(itemName.text);

        GameObject targetName = GameObject.Find(itemName.text);

        InventoryUI.instance.RemoveUIItem(itemName.text);
        Destroy(targetName);
    }

    public void useItem()
    {
        InventoryUIItem UIItem = instance;

        InventoryUI.instance.useItemInventory(itemName.text, UIItem);
    }

}
