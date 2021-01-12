using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Agent
{

    public int givenXP;
    public int healingItems;
    public int healingAmount;

    public bool canUseMagic;

    public EnemyStats(string name, int strength, int healthpoints, int maxHealthPoints, int vitality, int minAttackPower, int maxAttackPower , int armor, int dexterity, int dodge, GameObject targetAgent, bool myTurn ,int givenXP, int healingItems, int healingAmount, bool canUseMagic) : base(name, strength,healthpoints, maxHealthPoints, vitality,minAttackPower, maxAttackPower,armor,dexterity,dodge, targetAgent, myTurn)
    {
        this.givenXP = givenXP;
        this.healingItems = healingItems;
        this.healingAmount = healingAmount;
        this.canUseMagic = canUseMagic;
    }

    public bool updateXP(int GivenXP)
    {
        return givenXP == GivenXP;
    }
}
