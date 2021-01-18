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

    private bool inCombatInventory;

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
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Debug.Log(Items[i].name);
            }
        }

    }
    public void useItem(Item b, string itemName)
    {
        playerScript.combatCheckResult();

        if (inCombatInventory == true)
        {
            playerScript.giveTurn();
        }



        if (b != null)
        {
            if (b is Consumable)
            {

                Consumable f = (Consumable)b;

                playerScript.playerHeals(f.healthPointRestore);

                InventoryUI.instance.RemoveUIItem(f.name);
                GameObject Target = GameObject.Find(f.name);
                Destroy(Target);

            }

            if (b is Armor)
            {
                Armor h = (Armor)b;

                Debug.Log(h.name);
                Debug.Log(h.dodgePenalty);


            }

            if (b is Weapon)
            {
                Weapon j = (Weapon)b;

                Debug.Log(j.strengthNeeded);
                Debug.Log(j.name);



            }
        }
    }

    public void combatCheckRequest(bool inCombat)
    {
        inCombatInventory = inCombat;
    }
}
