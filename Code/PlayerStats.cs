using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Agent
{
    public int skillpoints;
    public int expierencePointsToLevel;
    public int currentExpierencePoints;
    public int level;
    public int currentEnergy;
    public int maxEnergy;
    public int currentHunger;
    public int maxHunger;
    public int runAwayChance;

    public PlayerStats(string name, int strength, int healthpoints, int maxHealthPoints, int vitality, int minAttackPower, int maxAttackPower, int armor, int dexterity, int dodge, GameObject targetAgent, bool myTurn, int skillpoints, int expierencePointsToLevel, int currentExpierencePoints, int level, int currentEnergy, int maxEnergy, int currentHunger, int maxHunger, int runAwayChance) : base(name, strength, healthpoints, maxHealthPoints, vitality, minAttackPower, maxAttackPower, armor, dexterity, dodge, targetAgent, myTurn)
    {
        this.skillpoints = skillpoints;
        this.expierencePointsToLevel = expierencePointsToLevel;
        this.currentExpierencePoints = currentExpierencePoints;
        this.level = level;
        this.currentEnergy = currentEnergy;
        this.maxEnergy = maxEnergy;
        this.currentHunger = currentHunger;
        this.maxHunger = maxHunger;
        this.runAwayChance = runAwayChance;
    }

    public bool setSkillPoints(int Skillpoints)
    {
        return skillpoints == Skillpoints;
    }

    public bool setNewexpierenceGoal(int ExpierencePointsToLevel)
    {
        return expierencePointsToLevel == ExpierencePointsToLevel;
    }

    public bool updateCurrentExpierencePoints(int CurrentExpierencePoints)
    {
        return currentExpierencePoints == CurrentExpierencePoints;
    }
    public bool setLevel(int Level)
    {
        return level == Level;
    }
}
