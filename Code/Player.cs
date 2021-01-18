using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private string playerName;

    [SerializeField] private int playerStrength;
    [SerializeField] private int playerHealthpoints;
    [SerializeField] private int playerMaxHealthPoints;
    [SerializeField] private int playerVitality;
    [SerializeField] private int playerDexterity;

    [SerializeField] private int playerMinAttackpower;
    [SerializeField] private int playerMaxAttackpower;
    [SerializeField] private int playerArmor;
    [SerializeField] private int playerDodge;

    [SerializeField] private int playerSkillpoints;
    [SerializeField] private int playerExpierencePointsToLevel;
    [SerializeField] private int playerCurrentExpierencePoints;
    [SerializeField] private int playerLevel;
    [SerializeField] private int playerCurrentEnergy;
    [SerializeField] private int playerMaxEnergy;
    [SerializeField] private int playerCurrentHunger;
    [SerializeField] private int playerMaxHunger;
    [SerializeField] private int playerRunAwayChance;

    private GameObject playerTargetAgent;
    [SerializeField] private Enemy playerTargetAgentScript;

    [SerializeField] private CharacterMovement walkingScript;
    [SerializeField] private combatManager combatManagerScript;

    [SerializeField] private bool playerTurn;
    [SerializeField] private bool gotPenalty;
    [SerializeField] private bool isInCombat;
    [SerializeField] public bool isInBase;

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

    }

    public void Start()
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

        Agent playerAgent = new PlayerStats(name: playerName, strength: playerStrength, healthpoints: playerHealthpoints, maxHealthPoints: playerMaxHealthPoints , vitality: playerVitality, minAttackPower: playerMinAttackpower, maxAttackPower: playerMaxAttackpower ,armor: playerArmor, dexterity: playerDexterity,dodge: playerDodge, targetAgent: playerTargetAgent, myTurn: playerTurn, skillpoints: playerSkillpoints, expierencePointsToLevel: playerExpierencePointsToLevel, currentExpierencePoints: playerCurrentExpierencePoints, level: playerLevel, currentEnergy:playerCurrentEnergy, maxEnergy: playerMaxEnergy, currentHunger:playerCurrentHunger, maxHunger: playerMaxHunger, runAwayChance: playerRunAwayChance);
        statsInfluence();
    }

    public void Update()
    {
        if(playerTurn == true)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                Invoke("giveDamage", 0.25f);
            }
        }
    }

    public void CombatStarts()
    {
        isInCombat = true;
        playerTargetAgent = GameObject.FindGameObjectWithTag("Enemy");
        playerTargetAgentScript = playerTargetAgent.GetComponent<Enemy>();
        walkingScript.enabled = false;
        walkingScript.combatReadyAnimation();
        combatManagerScript.combatStartUp();

        //UI shows up


    }

    public void getsHit(int incomingDamage)
    {

        int chanceDodge;
        chanceDodge = Random.Range(1, 101);

        Debug.Log(chanceDodge);

        if (chanceDodge < playerDodge)
        {
            Debug.Log("player dodged");
            walkingScript.dodgeAnimation();
            return;
        }
        else
        {
            walkingScript.getsHitAnimation();

            Debug.Log("incoming damage before armor" + incomingDamage);

            incomingDamage = incomingDamage - playerArmor;

            Debug.Log("incoming damage after armor" + incomingDamage);

            playerHealthpoints -= incomingDamage;

            Debug.Log("player gets hit");

            if (playerHealthpoints < 1)
            {
                Debug.Log("player died");
                //player dying 
            }
        }
    }

    public void giveDamage()
    {
        Debug.Log("player gives damage");

        walkingScript.attackAnimation();

        int rngAttackPower;
        rngAttackPower = Random.Range(playerMinAttackpower, playerMaxAttackpower);

        playerTargetAgentScript.getsHit(rngAttackPower);

        Invoke("giveTurn", 0.35f);

    }

    public void getExpierencePoints(int incomingExpierencePoints)
    {
        playerCurrentExpierencePoints += incomingExpierencePoints;

        if(playerCurrentExpierencePoints > playerExpierencePointsToLevel)
        {
            playerLevel++;
            playerSkillpoints++;

            Debug.Log("player leveled up");
            playerCurrentExpierencePoints = playerCurrentExpierencePoints - playerExpierencePointsToLevel;
            playerExpierencePointsToLevel = playerExpierencePointsToLevel * 3;
        }
    }

    public void getsTurn(bool turnCheck)
    {

        playerTurn = turnCheck;
        if (playerTurn == true)
        {
            Debug.Log("player got turn");
            return;
        }
        else
        {

            return;
        }
    }

    public void giveTurn()
    {

        if (playerTargetAgentScript == null)
        {
            Debug.Log("no enemy to be seen");
            return;
        }

        playerTargetAgentScript.getsTurn(true);
        playerTurn = false;
    }

    public void outOfCombat()
    {
        isInCombat = false;
        walkingScript.Invoke("combatDoneAnimation", 2);
        walkingScript.enabled = true;
        playerTurn = false;
        playerCurrentEnergy -= 15;
        penaltyCheck();
    }

    public void runAwayAttempt()
    {
        int rngRunAwayChance;
        rngRunAwayChance = Random.Range(0, 101);

        if (rngRunAwayChance > playerRunAwayChance)
        {
            runningAway();
        }
    }

    public void runningAway()
    {
        playerCurrentEnergy -= 20;
        penaltyCheck();
    }

    public void statsInfluence()
    {
        playerDodge = playerDodge + playerDexterity;

        playerMaxHealthPoints = playerMaxHealthPoints + 5 * playerVitality;

        playerMinAttackpower = playerMinAttackpower + playerStrength;
        playerMaxAttackpower = playerMaxAttackpower + playerStrength;
    }

    public void penaltyCheck()
    {
        if (playerCurrentEnergy < 1 && gotPenalty == false)
        {
            gotPenalty = true;

            playerCurrentEnergy = 0;
            int penalty;
            penalty = -3;

            playerStrength += penalty;
            playerDexterity += penalty;
            playerVitality += penalty;

            statsInfluence();
        }

        if (playerCurrentEnergy > 1 && gotPenalty == true)
        {

            gotPenalty = false;

            int recoverStats;
            recoverStats = 3;

            playerStrength += recoverStats;
            playerDexterity += recoverStats;
            playerVitality += recoverStats;

            statsInfluence();
        }
    }

    public void combatCheckResult()
    {
        bool inCombat;
        inCombat = isInCombat;

        Inventory.instance.combatCheckRequest(inCombat);
    }

    public void playerHeals(int healingpoints)
    {
        if(playerHealthpoints < playerMaxHealthPoints)
        {
            playerHealthpoints += healingpoints;
            if(playerHealthpoints > playerMaxHealthPoints)
            {
                playerHealthpoints = playerMaxHealthPoints;
            }
        }
    }

}
