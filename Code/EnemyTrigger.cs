using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    [SerializeField] private GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Enemy.SetActive(true);
            Player playerScript;
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            Enemy enemyScript;
            enemyScript = Enemy.GetComponent<Enemy>();
            enemyScript.scanTarget();
            playerScript.CombatStarts();
            playerScript.setEnemyTrigger(this.gameObject);
        }
    }
}
