using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("Generics")]
    public bool isActive;
    public bool completed;
    public string title;
    public List<Goal> goals = new List<Goal>();
    [TextArea] public string description;
    [Header("Rewards")]
    public int experienceReward;
    public Item itemReward;

    public void Complete()
    {
        isActive = false;
        completed = true;
        Debug.Log(title + " has been completed!");
    }
}