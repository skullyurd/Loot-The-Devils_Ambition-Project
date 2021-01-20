using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private GameObject sleepButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player playerScript;
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            playerScript.setCheckPoint(this.gameObject.transform);
        }
    }
}
