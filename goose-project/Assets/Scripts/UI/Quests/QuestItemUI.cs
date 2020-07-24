using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{
    public Quest quest;

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
        SetupQuestValues();
    }

    private void SetupQuestValues()
    {
        transform.Find("QuestTitle").GetComponent<TextMeshProUGUI>().text = quest.title;
        transform.Find("QuestDescription").GetComponent<TextMeshProUGUI>().text = quest.description;
    }

    public void OnSelectQuestButton()
    {
        UIManager.Instance.SetQuestDetails(quest, GetComponent<Button>());
    }
}
