using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //properties
    [SerializeField] public static Inventory instance;

    [SerializeField] private GameObject player;

    public List<Item> Items;
    public int maxSlots = 10;
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
            
            return true;
        }
        else
        {
            return false;
        }
    }
    public int Count()
    {
        return Items.Count;
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


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha0))
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Debug.Log(Items[i].name);
            }
        }

    }
    public void useItem(Item b, string itemName, InventoryUIItem UIITem)
    {
        if (b != null)
        {
            if (b is Consumable)
            {

                InventoryUIItem deleteUIItem = UIITem;

                Consumable f = (Consumable)b;

                Debug.Log(f.healthPointRestore);
                Debug.Log(f.name);

                InventoryUIItem.instance.itemName.text = f.name;

                deleteUIItem.HandleClick();



            }

            if (b is Armor)
            {
                Armor h = (Armor)b;

                Debug.Log(h.name);
                Debug.Log(h.dodgePenalty);


            }

            if(b is Weapon)
            {
                Weapon j = (Weapon)b;

                Debug.Log(j.strengthNeeded);
                Debug.Log(j.name);



            }

        }
    }
}
