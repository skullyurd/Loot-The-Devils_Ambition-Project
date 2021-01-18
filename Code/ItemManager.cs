using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventoryCanvas;


    // Start is called before the first frame update
    private void Awake()
    {
        GameObject findPlayer;
        findPlayer = GameObject.FindGameObjectWithTag("Player");

        if (findPlayer == null)
        {
            Instantiate(player, new Vector3(-2.5f, 0, -4), Quaternion.identity);
            return;
        }
        else
        {
            print("enemy found");
            return;
        }
    }
}
