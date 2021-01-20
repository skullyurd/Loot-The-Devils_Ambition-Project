using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryBase : MonoBehaviour
{
    //properties
    [SerializeField] public static InventoryBase instance;

    [SerializeField] private GameObject player;
    [SerializeField] private Player playerScript;

    [SerializeField] private int wood;
    [SerializeField] private int iron;
    [SerializeField] private int leather;
    [SerializeField] private int stone;

    public List<Item> Items;
    public int maxSlots = 32;
    public int usedSlots = 0;

    public GameObject[] interactableItems;

    /*[SerializeField] public List<GameObject> medcineItems;
    [SerializeField] public List<GameObject> WeaponItems;
    [SerializeField] public List<GameObject> ArmorItems;
    [SerializeField] public List<GameObject> materialItems;
    [SerializeField] public List<GameObject> foodItems;*/

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(obj: this);
        }

        Debug.Log(instance);

        usedSlots = 0;
        Items = new List<Item>();

    }
    //methods
    public bool AddItem(Item i)
    {
        if (usedSlots + i.slotSpace <= maxSlots)
        {

            Items.Add(i);

            usedSlots += i.slotSpace;
            materialCheck();

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveItem(Item b)
    {
        if (b != null)
        {
            usedSlots -= b.slotSpace;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void materialCheck()
    {
        foreach (Item b in Items)
        {
            if (b != null)
            {
                if (b is CraftingMaterial)
                {

                    if(b.itemType == "Wood")
                    {
                        InventoryUIBase.instance.RemoveUIItem(b.name);
                        wood++;
                        return;
                    }
                    if (b.itemType == "Irom")
                    {
                        iron++;
                        return;
                    }
                    if (b.itemType == "Leather")
                    {
                        leather++;
                        return;
                    }
                    if (b.itemType == "Stone")
                    {
                        stone++;
                        return;
                    }

                }
            }
        }

    }
}
