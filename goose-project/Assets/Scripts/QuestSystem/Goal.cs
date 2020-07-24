using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal
{
    public string goalDescription;
    public GoalType goalType;
    public Item requiredItem;
    public int currentAmount;
    public int requiredAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemGathered()
    {
        if (goalType == GoalType.Gathering)
            currentAmount++;
    }
}

public enum GoalType
{
    Kill,
    Gathering
}
