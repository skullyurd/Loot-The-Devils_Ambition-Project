using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent
{

    public string name;

    public int strength;
    public int healthpoints;
    public int maxHealthpoints;
    public int vitality;

    public int minAttackPower;
    public int maxAttackPower;
    public int armor;
    public int dexterity;
    public int dodge;

    public GameObject targetAgent;

    public bool myTurn;


    public Agent(string name, int strength, int healthpoints, int maxHealthPoints ,int vitality, int minAttackPower, int maxAttackPower, int armor, int dexterity, int dodge, GameObject targetAgent, bool myTurn)
    {
            this.name = name;

            this.strength = strength;
            this.healthpoints = healthpoints;
            this.maxHealthpoints = maxHealthPoints;
            this.vitality = vitality;

            this.minAttackPower = minAttackPower;
            this.maxAttackPower = maxAttackPower;
            this.armor = armor;
            this.dexterity = dexterity;
            this.dodge = dodge;

            this.targetAgent = targetAgent;

            this.myTurn = myTurn;
    }

}
