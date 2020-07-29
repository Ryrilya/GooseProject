using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuUI : MonoBehaviour
{
    public GameObject questMenu;
    public GameObject scrollViewContent;
    public GameObject questContainerPrefab;

    private QuestItemUI questItem; 
    private Quest currentSelectedQuest;

    // Start is called before the first frame update
    void Start()
    {
        questItem = questContainerPrefab.GetComponent<QuestItemUI>();
        UIEventHandler.OnQuestAddedToPlayer += QuestAdded;
    }

    private void Update()
    {
        if (Input.GetButtonDown("QuestMenu"))
            questMenu.gameObject.SetActive(!questMenu.gameObject.activeSelf);
    }

    public void QuestAdded(Quest quest)
    {
        GameObject emptyQuestItem = Instantiate(questContainerPrefab);
        emptyQuestItem.GetComponent<QuestItemUI>().SetQuest(quest);
        emptyQuestItem.transform.SetParent(scrollViewContent.transform);
        emptyQuestItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
