using System.Collections;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void QuestEventHandler(Quest quest);
    public static event QuestEventHandler OnQuestAddedToPlayer;

    public static void QuestAddedToPlayer(Quest quest)
    {
        OnQuestAddedToPlayer(quest);
    }
}
