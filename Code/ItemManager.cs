using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventoryCanvas;
    [SerializeField] private GameObject combatManager;


    // Start is called before the first frame update
    private void Awake()
    {
        GameObject findPlayer;
        findPlayer = GameObject.FindGameObjectWithTag("Player");

        GameObject findUI;
        findUI = GameObject.FindGameObjectWithTag("Canvas");

        GameObject cManager;
        cManager = GameObject.Find("Combat Manager");

        if (findPlayer == null)
        {
            Instantiate(combatManager, new Vector3(0, 0, 0), Quaternion.identity);
        }

        if (findPlayer == null)
        {
            Instantiate(player, new Vector3(-2.5f, 0, -4), Quaternion.identity);
        }

        if (findUI == null)
        {
            Instantiate(inventoryCanvas,new Vector3(0,0,0) , Quaternion.identity);
        }
    }
}
