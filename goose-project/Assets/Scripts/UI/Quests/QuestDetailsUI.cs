using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestDetailsUI : MonoBehaviour
{
    public Button selectedQuestButton;
    public TextMeshProUGUI questTitleText;
    public TextMeshProUGUI questDescriptionText;

    private Quest _quest;

    public void SetQuest(Quest quest, Button selectedButton)
    {
        _quest = quest;
        selectedQuestButton = selectedButton;
        questTitleText.text = quest.title;
        questDescriptionText.text = quest.description;
    }
}
