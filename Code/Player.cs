using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public static Player instance;

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

    [SerializeField] private Image energyFill;
    [SerializeField] private Image HealthFill;
    [SerializeField] private Image XPFill;

    private GameObject playerTargetAgent;
    [SerializeField] private Enemy playerTargetAgentScript;

    [SerializeField] private CharacterMovement walkingScript;
    [SerializeField] private combatManager combatManagerScript;

    [SerializeField] private bool playerTurn;
    [SerializeField] private bool gotPenalty;
    [SerializeField] private bool isInCombat;
    [SerializeField] public bool isInBase;

    [SerializeField] private bool gotBonus;

    [SerializeField] private Transform checkPoint;
    [SerializeField] private GameObject EnemyTrigger;

    [SerializeField] private Text strengthText;
    [SerializeField] private Text dexterityText;
    [SerializeField] private Text vitalityText;
    [SerializeField] private Text skillpointsText;

    [SerializeField] private Text levelText;
    [SerializeField] private Text dodgeText;
    [SerializeField] private Text attackPowerText;
    [SerializeField] private Text armorText;

    [SerializeField] private GameObject improveStrength;
    [SerializeField] private GameObject improveVitality;
    [SerializeField] private GameObject improveDexterity;
    [SerializeField] private GameObject homeButton;
    [SerializeField] private AudioClip[] wildernessMusic;
    [SerializeField] private AudioSource thisAuido;

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
        Agent playerAgent = new PlayerStats(name: playerName, strength: playerStrength, healthpoints: playerHealthpoints, maxHealthPoints: playerMaxHealthPoints , vitality: playerVitality, minAttackPower: playerMinAttackpower, maxAttackPower: playerMaxAttackpower ,armor: playerArmor, dexterity: playerDexterity,dodge: playerDodge, targetAgent: playerTargetAgent, myTurn: playerTurn, skillpoints: playerSkillpoints, expierencePointsToLevel: playerExpierencePointsToLevel, currentExpierencePoints: playerCurrentExpierencePoints, level: playerLevel, currentEnergy:playerCurrentEnergy, maxEnergy: playerMaxEnergy, currentHunger:playerCurrentHunger, maxHunger: playerMaxHunger, runAwayChance: playerRunAwayChance);

        energyFill = GameObject.Find("Energy_Bar/Filler").GetComponent<Image>();
        XPFill = GameObject.Find("XP_Bar/Filler").GetComponent<Image>();
        HealthFill = GameObject.Find("Health_Bar/Filler").GetComponent<Image>();
        combatManagerScript = GameObject.FindGameObjectWithTag("ManagerFight").GetComponent<combatManager>();

        strengthText = GameObject.Find("Strength_text").GetComponent<Text>();
        dexterityText = GameObject.Find("dexterity_text").GetComponent<Text>();
        vitalityText = GameObject.Find("Vitality_text").GetComponent<Text>();
        skillpointsText = GameObject.Find("Skillpoints_text").GetComponent<Text>();

        levelText = GameObject.Find("Level_text").GetComponent<Text>();
        dodgeText = GameObject.Find("dodge_text").GetComponent<Text>();
        attackPowerText = GameObject.Find("attackPower_text").GetComponent<Text>();
        armorText = GameObject.Find("Armor_text").GetComponent<Text>();

        improveDexterity = GameObject.Find("improve_dexterity");
        improveStrength = GameObject.Find("improve_Strength");
        improveVitality = GameObject.Find("improve_vitality");

        thisAuido.clip = wildernessMusic[0];
        thisAuido.Play();

        improveDexterity.SetActive(false);
        improveStrength.SetActive(false);
        improveVitality.SetActive(false);

        statsInfluence();

        updateEnergyBar();
        updateHealthBar();
        updateXPBar();
    }

    public void CombatStarts()
    {
        homeButton = GameObject.Find("GoHome_Button");

        homeButton.SetActive(false);

        isInCombat = true;
        playerTargetAgent = GameObject.FindGameObjectWithTag("Enemy");
        playerTargetAgentScript = playerTargetAgent.GetComponent<Enemy>();
        walkingScript.enabled = false;
        walkingScript.combatReadyAnimation();
        combatManagerScript.combatStartUp();

        thisAuido.clip = wildernessMusic[1];
        thisAuido.Play();
    }

    public void getsHit(int incomingDamage)
    {

        int chanceDodge;
        chanceDodge = Random.Range(1, 101);

        Debug.Log(chanceDodge);

        if (chanceDodge < playerDodge)
        {
            walkingScript.dodgeAnimation();
            return;
        }
        else
        {
            walkingScript.getsHitAnimation();

            incomingDamage = incomingDamage - playerArmor;

            playerHealthpoints -= incomingDamage;

            updateHealthBar();

            if (playerHealthpoints < 1)
            {
                walkingScript.dieAnimation();
                Invoke("gameOverScreen", 1.5f);
            }
        }
        removeBonus();
    }

    public void giveDamage()
    {
        if (playerTurn == true)
        {
            walkingScript.attackAnimation();

            int rngAttackPower;
            rngAttackPower = Random.Range(playerMinAttackpower, playerMaxAttackpower);

            playerTargetAgentScript.getsHit(rngAttackPower);

            Invoke("giveTurn", 0.35f);
        }
    }

    public void getExpierencePoints(int incomingExpierencePoints)
    {
        playerCurrentExpierencePoints += incomingExpierencePoints;

        updateXPBar();

        if (playerCurrentExpierencePoints > playerExpierencePointsToLevel)
        {
            playerLevel++;
            playerSkillpoints += 2;
            levelText.text = "Level: " + playerLevel;
            skillpointsText.text = "Skillpoints: " + playerSkillpoints;

            playerCurrentExpierencePoints = playerCurrentExpierencePoints - playerExpierencePointsToLevel;
            playerExpierencePointsToLevel = playerExpierencePointsToLevel * 3;

            updateXPBar();
            improveStatsActive();
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
        homeButton.SetActive(true);

        thisAuido.clip = wildernessMusic[0];
        thisAuido.Play();

        isInCombat = false;
        walkingScript.Invoke("combatDoneAnimation", 1f);
        walkingScript.enabled = true;
        playerTurn = false;
        playerCurrentEnergy -= 15;
        updateEnergyBar();
        penaltyCheck();
        combatManagerScript.UIreset();
    }

    public void runAwayAttempt()
    {
        if(playerTurn == true)
        {
            int rngRunAwayChance;
            rngRunAwayChance = Random.Range(0, 101);

            if (rngRunAwayChance > playerRunAwayChance)
            {
                runningAway();
            }
            if (rngRunAwayChance < playerRunAwayChance)
            {
                giveTurn();
            }
        }
    }

    public void runningAway()
    {
        playerCurrentEnergy -= 5;

        gameObject.transform.position = checkPoint.transform.position;
        playerTargetAgent.SetActive(false);

        outOfCombat();
    }

    public void statsInfluence()
    {
        playerDodge += playerDexterity;

        playerMaxHealthPoints += 5 * playerVitality;

        playerMinAttackpower += playerStrength;
        playerMaxAttackpower += playerStrength;

        levelText.text = "Level: " + playerLevel;
        dodgeText.text = "Dodge: " + playerDodge;
        attackPowerText.text = "Damage: " + playerMinAttackpower + " - " + playerMaxAttackpower;
        armorText.text = "Armor: " + playerArmor;

        skillpointsText.text = "Skillpoints: " + playerSkillpoints;
        strengthText.text = "Strength: " + playerStrength;
        dexterityText.text = "Dexterity: " + playerDexterity;
        vitalityText.text = "Vitality: " + playerVitality;

        updateHealthBar();
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

        updateHealthBar();

    }

    public void wearWeapon()
    {

    }

    public void wearArmor()
    {

    }

    public bool statusCheck(int strengthneeded, int dexterityneeded)
    {

        if (playerStrength == strengthneeded && playerDexterity == dexterityneeded || playerStrength > strengthneeded && playerDexterity > dexterityneeded)
        {

            return true;
        }
        else
        {
            
            return false;
        }
    }

    public void updateHealthBar()
    {
        HealthFill.fillAmount = (float)playerHealthpoints / (float)playerMaxHealthPoints;
    }

    public void updateXPBar()
    {
        XPFill.fillAmount = (float)playerCurrentExpierencePoints / (float)playerExpierencePointsToLevel;
    }

    public void updateEnergyBar()
    {
        energyFill.fillAmount = (float)playerCurrentEnergy / (float)playerMaxEnergy;
    }

    public void setEnemyTrigger(GameObject HostileTrigger)
    {
        EnemyTrigger = HostileTrigger;
    }

    public void setCheckPoint(Transform checkPointTrigger)
    {
        checkPoint = checkPointTrigger.transform;
    }

    public void braceyourselfAction()
    {
        if(gotBonus == false)
        {
            gotBonus = true;
            playerDodge += 25;
            playerArmor += 10;
        }
        Invoke("giveTurn", 0.35f);
    }

    public void removeBonus()
    {
        if (gotBonus == true)
        {
            gotBonus = false;
            playerDodge -= 25;
            playerArmor -= 10;
        }
    }

    public void improveStatsActive()
    {
        improveDexterity.SetActive(true);
        improveStrength.SetActive(true);
        improveVitality.SetActive(true);
    }

    public void upgradeVitality()
    {
        playerVitality++;
        playerSkillpoints--;
        statsInfluence();
        if (playerSkillpoints < 1)
        {
            improveDexterity.SetActive(false);
            improveStrength.SetActive(false);
            improveVitality.SetActive(false);
        }
    }

    public void upgradeStrength()
    {
        playerStrength++;
        playerSkillpoints--;
        statsInfluence();
        if (playerSkillpoints < 1)
        {
            improveDexterity.SetActive(false);
            improveStrength.SetActive(false);
            improveVitality.SetActive(false);
        }
    }

    public void upgradeDexterity()
    {
        playerDexterity++;
        playerSkillpoints--;
        statsInfluence();
        if (playerSkillpoints < 1)
        {
            improveDexterity.SetActive(false);
            improveStrength.SetActive(false);
            improveVitality.SetActive(false);
        }
    }

    public void gameOverScreen()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }

        SceneManager.LoadScene(4);
    }
}
