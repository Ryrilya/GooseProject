using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{
    public Quest quest;

    private QuestDetailsUI _questDetailsUI;
    private bool isClicked = false;

    private void Start()
    {
        _questDetailsUI = UIManager.Instance.GetComponent<QuestDetailsUI>();
    }

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
        if (!isClicked)
        {
            _questDetailsUI.SetQuestDetails(quest, GetComponent<Button>());
            isClicked = true;

            // Da migliorare
        }
    }
}
