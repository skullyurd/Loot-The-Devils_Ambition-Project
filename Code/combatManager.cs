using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatManager : MonoBehaviour
{

    [SerializeField] private Player playerScript;

    private Enemy enemyScript;

    private void Start()
    {
        if (playerScript == null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    public void combatStartUp()
    {
        if(playerScript == null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        int turnRandom = Random.Range(0, 2);

        switch (turnRandom)
        {
            case 0:
                playerScript.getsTurn(true);
                enemyScript.getsTurn(false);
                break;

            case 1:
                playerScript.getsTurn(false);
                enemyScript.getsTurn(true);
                break;
        }    


        //UI shows up
        //first turn gets randomly chosen
        //makes sure each char gets a turn
        //gives turn to the right char

    }
}
