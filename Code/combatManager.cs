using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatManager : MonoBehaviour
{

    [SerializeField] private Player playerScript;
    [SerializeField] private Enemy enemyScript;

    public void combatStartUp()
    {
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

        int turnRandom = Random.Range(0, 2);

        Debug.Log("turn coin is flipped");
        Debug.Log(turnRandom);

        switch (turnRandom)
        {
            case 0:
                playerScript.getsTurn(true);
                enemyScript.getsTurn(false);
                Debug.Log("player got the first turn");
                break;

            case 1:
                playerScript.getsTurn(false);
                enemyScript.getsTurn(true);
                Debug.Log("enemy got the first turn");


                break;
        }    


        //UI shows up
        //first turn gets randomly chosen
        //makes sure each char gets a turn
        //gives turn to the right char

    }
}
