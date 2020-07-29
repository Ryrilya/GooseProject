using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestManager : MonoSingleton<QuestManager>
{
    public Interactable currentActiveInteractable;
    [SerializeField] private Quest _quest;

    [Header("References")]
    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI itemText;
    public Image itemIcon;

    private Player _player;
    private PlayerController _playerController;

    private void Start()
    {
        // DialogueSystem.Instance.OnDialogueClose += OpenQuestWindow;
        _player = Player.Instance;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        _quest = currentActiveInteractable.quest;
        titleText.text = _quest.title;
        descriptionText.text = _quest.description;
        experienceText.text = _quest.experienceReward.ToString();
        itemText.text = _quest.itemReward.name;
        itemIcon.sprite = _quest.itemReward.icon;
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        _quest.isActive = true;
        _player.quests.Add(_quest);
        UIEventHandler.QuestAddedToPlayer(_quest);
        _playerController.RemoveFocus();
        ResetInteractable();
    }

    public void DeclineQuest()
    {
        questWindow.SetActive(false);
        ResetInteractable();
    }

    private void ResetInteractable()
    {
        if (currentActiveInteractable.GetComponent<PatrolFreedom>())
        {
            currentActiveInteractable.transform.LookAt(GameObject.Find("KiwiPosition").transform);
            currentActiveInteractable.GetComponent<PatrolFreedom>().enabled = true;
        }
        else if(currentActiveInteractable.GetComponent<PatrolWithSpots>())
            currentActiveInteractable.GetComponent<PatrolWithSpots>().enabled = true;
    }

    public void CheckItemGathered(Item item)
    {
        foreach(Quest q in _player.quests)
        {
            foreach(Goal g in q.goals)
            {
                if(g.requiredItem.name == item.name)
                {
                    g.ItemGathered();
                    if (g.IsReached())
                    {
                        q.Complete();
                    }
                }
            }
        }
    }
}