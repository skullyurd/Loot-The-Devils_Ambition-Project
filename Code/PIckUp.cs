using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckUp : MonoBehaviour
{

    public Item item;

    public string _name;
    public Sprite InventoryIcon;

    public virtual void Start()
    {

    }


    public void Action()
    {
        Inventory.instance.AddItem(item);
        InventoryUI.instance.AddUIItem(this);
        this.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            if (Inventory.instance.usedSlots + item.slotSpace <= Inventory.instance.maxSlots)
            {
                Action();
            }
            else
            {
                Debug.Log("You can't carry this");
            }
        }
    }
}
