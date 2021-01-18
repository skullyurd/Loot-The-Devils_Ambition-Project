using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private string creatureName;

    [SerializeField] private int creatureStrength;
    [SerializeField] private int creatureHealthpoints;
    [SerializeField] private int creatureMaxHealthPoints;
    [SerializeField] private int creatureVitality;
    [SerializeField] private int creatureDexterity;

    [SerializeField] private int creatureMinAttackpower;
    [SerializeField] private int creatureMaxAttackpower;
    [SerializeField] private int creatureArmor;
    [SerializeField] private int creatureDodge;
    [SerializeField] private int creatureGivenxp;

    [SerializeField] private int creatureHealingItems;
    [SerializeField] private int creatureHealingAmount;

    [SerializeField] private int creatureMagicCharges;
    [SerializeField] private int creatureMagicDamage;

    [SerializeField] private GameObject creatureTargetAgent;
    [SerializeField] private GameObject[] possibleLoot;

    private Player creatureTargetAgentScript;

    [SerializeField] private bool creatureCanUseMagic;

    private bool creatureTurn;

    [SerializeField] private Animator thisAnimator;

    [SerializeField] private string idleAnimationName;
    [SerializeField] private string hitAnimationName;
    [SerializeField] private string magicAnimationName;
    [SerializeField] private string dodgeAnimationName;
    [SerializeField] private string attackAnimationName;
    [SerializeField] private string healAnimationName;
    [SerializeField] private string combatReadyAnimationName;
    [SerializeField] private string dyingAnimationName;

    public void Start()
    {

        Agent HostileAgent = new EnemyStats(name: creatureName, strength: creatureStrength, healthpoints: creatureHealthpoints, maxHealthPoints: creatureMaxHealthPoints ,vitality: creatureVitality, minAttackPower: creatureMinAttackpower, maxAttackPower: creatureMaxAttackpower, armor: creatureArmor, dexterity: creatureDexterity, dodge: creatureDodge, targetAgent: creatureTargetAgent, myTurn: creatureTurn ,givenXP: creatureGivenxp, healingItems: creatureHealingItems, healingAmount: creatureHealingAmount, canUseMagic: creatureCanUseMagic);
        thisAnimator.SetBool(idleAnimationName, true);
        thisAnimator.SetBool(combatReadyAnimationName, true);
        
        this.transform.eulerAngles = new Vector3(0, -90, 0);
    }

    public void scanTarget()
    {
        creatureTargetAgent = GameObject.FindGameObjectWithTag("Player");
        creatureTargetAgentScript = creatureTargetAgent.GetComponent<Player>();
    }

    public void getsHit(int incomingDamage)
    {

        int chanceDodge;
        chanceDodge = Random.Range(1, 101);

        Debug.Log(chanceDodge);

        if(chanceDodge < creatureDodge)
        {
            Debug.Log("creature dodged");
            thisAnimator.SetBool(dodgeAnimationName, false);
            thisAnimator.SetBool(dodgeAnimationName, true);

            return;
        }
        else
        {

            creatureHealthpoints -= incomingDamage;

            if (creatureHealthpoints > 0)
            {
                thisAnimator.SetBool(hitAnimationName, false);
                thisAnimator.SetBool(hitAnimationName, true);

                Debug.Log("creature got hit");
            }
            if (creatureHealthpoints < 1)
            {
                creatureDying();
            }
        }
    }

    public void giveDamage()
    {
        Debug.Log("creature gives damage");

        //attack animation
        thisAnimator.SetBool(attackAnimationName, false); //or block animation, health gets the same effect anyways
        thisAnimator.SetBool(attackAnimationName, true);

        int rngAttackPower;
        rngAttackPower = Random.Range(creatureMinAttackpower, creatureMaxAttackpower);

        creatureTargetAgentScript.getsHit(rngAttackPower);

        Invoke("giveTurn", 1.5f);
    }

    public void creatureDying()
    {
        //dying animation
        thisAnimator.SetBool(dyingAnimationName, true);


        creatureTargetAgentScript.getExpierencePoints(creatureGivenxp);
        Debug.Log("creature died");

        creatureTargetAgentScript.outOfCombat();
        Invoke("dropLoot", 3);
    }
    public void getsTurn(bool turnCheck)
    {
        creatureTurn = turnCheck;

        if(creatureTurn == false)
        {
            return;
        }
        if(creatureTurn == true)
        {
            if(creatureHealthpoints > 0)
            {
                Debug.Log("creature got turn");

                int diceAction;
                diceAction = Random.Range(0, 3);

                switch (diceAction)
                {
                    case 0:
                        Invoke("giveDamage", 1.5f);
                        break;

                    case 1:

                        //heal animation?

                        Invoke("creatureHeals", 1.5f);
                        break;

                    case 2:        //magic
                        if (creatureCanUseMagic == true)
                        {
                            if(creatureMagicCharges > 0)
                            {
                                creatureMagicCharges--;

                                thisAnimator.SetBool(magicAnimationName, false);
                                thisAnimator.SetBool(magicAnimationName, true);

                                Invoke("giveTurn", 3);
                                creatureTurn = false;
                                creatureTargetAgentScript.getsTurn(true);
                                creatureTargetAgentScript.getsHit(creatureMagicDamage);

                                Debug.Log("creature turns ended");
                                break;
                            }
                        }
                        if (creatureCanUseMagic == false || creatureMagicCharges < 1)
                        {
                            Debug.Log("the creature wanted to use magic but couldn't do it.");
                            Invoke("giveDamage", 1.5f);
                        }
                        creatureTurn = false;
                        creatureTargetAgentScript.getsTurn(true);
                        Debug.Log("creature turns ended");
                        break;
                }
            }
        }
    }

    public void giveTurn()
    {
        creatureTurn = false;
        creatureTargetAgentScript.getsTurn(true);
        Debug.Log("creature turns ended");
    }

    public void creatureHeals()
    {

        Debug.Log("the creature rolled healing");


        if (creatureHealthpoints > creatureMaxHealthPoints/5 || creatureHealingItems < 1)
        {
            Debug.Log("the creature wanted to heal but didn't/couldn't do it");

            Invoke("giveDamage", 1.5f);
        }

        if (creatureHealthpoints < 20 && creatureHealingItems > 0)
        {
            creatureHealingItems--;
            creatureHealthpoints += creatureHealingAmount;

            Debug.Log("the creature heals");
            Invoke("giveTurn", 0.50f);
        }

    }

    public void dropLoot()
    {
        if(possibleLoot[0] == null)
        {
            Destroy(this.gameObject);
            return;
        }

        int rngLoot;
        rngLoot = Random.Range(0, possibleLoot.Length);

        Debug.Log(possibleLoot.Length);

        Debug.Log(rngLoot);

        Instantiate(possibleLoot[rngLoot], new Vector3(this.transform.position.x, 0, this.transform.position.z) , Quaternion.identity);

        Destroy(this.gameObject);
    }
}
