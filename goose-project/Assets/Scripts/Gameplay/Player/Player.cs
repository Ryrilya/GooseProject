using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    public int health = 5;
    public int experience = 40;
    public int gold = 1000;
    public List<Quest> quests = new List<Quest>();
}