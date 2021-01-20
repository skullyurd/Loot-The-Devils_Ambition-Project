using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatManager : MonoBehaviour
{

    [SerializeField] private Player playerScript;

    [SerializeField] private Enemy enemyScript;

    [SerializeField] private GameObject combatPanel;
    [SerializeField] private GameObject statsPanel;

    private void Start()
    {

        if (playerScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        statsPanel = GameObject.Find("stat_Panel");

        combatPanel = GameObject.Find("Combat_UI");
        combatPanel.SetActive(false);
    }

    public void combatStartUp()
    {
        if(playerScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

        combatPanel.SetActive(true);
        statsPanel.SetActive(false);
    }

    public void UIreset()
    {
        combatPanel.SetActive(false);
        statsPanel.SetActive(true);
    }
}
