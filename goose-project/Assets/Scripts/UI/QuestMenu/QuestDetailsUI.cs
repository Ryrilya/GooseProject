using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestDetailsUI : MonoBehaviour
{
    public GameObject questDetailsPanel;
    public TextMeshProUGUI questTitleText;
    public TextMeshProUGUI questDescriptionText;
    public TextMeshProUGUI questObjectivesText;
    public TextMeshProUGUI xpRewardText;
    public Image iconItem;
    public TextMeshProUGUI itemRewardText;

    private Quest _quest;

    public void SetQuestDetails(Quest quest, Button selectedButton)
    {
        // sets properties in actual UI
        questDetailsPanel.SetActive(true);
        questTitleText.text = quest.title;
        questDescriptionText.text = quest.description;
        GenerateObjectivesText(quest);  // generates objective string based on goals in given quest
        xpRewardText.text = quest.experienceReward.ToString();
        iconItem.sprite = quest.itemReward.icon;
        itemRewardText.text = quest.itemReward.name;
    }

    private void GenerateObjectivesText(Quest quest)
    {
        int i = 1;
        foreach (Goal goal in quest.goals)
        {
            questObjectivesText.text += i + ") " + goal.goalDescription + "\n"; // 1) Raccogli questa cosa
            i++;
        }
    }
}
