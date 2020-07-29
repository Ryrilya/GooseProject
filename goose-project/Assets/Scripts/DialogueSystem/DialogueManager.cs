using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    // Variables
    #region Public Variables
    [Header("References", order = 0)]
    [Header("├ Dialogue Box", order = 1)]
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;
    public Animator textDisplayAnimator;
    [Header("└ Dialogue with Options", order = 1)]
    public GameObject dialogueOptionsUI;
    public GameObject[] optionButtons;
    public TextMeshProUGUI questionText;

    [Header("Settings", order = 0)]
    [Range(0.001f, 1f)] public float textSlowness = 0.001f;
    public Queue<DialogueBase.Info> dialogueInfo = new Queue<DialogueBase.Info>();  // FIFO (First-In-First-Out) Collection
    #endregion
    #region Private Variables
    private AudioSource _audioSource;
    private bool _isDialogueOption;
    private int _optionsAmount;
    private bool _isCurrentlyTyping;
    private string completeText;
    private readonly List<char> punctuationCharacters = new List<char>
    {
        '.',
        ',',
        '!',
        '?'
    };

    private AudioManager _audioManager;
    #endregion

    // Methods
    #region Public Methods
    public void EnqueueDialogue(DialogueBase db)
    {
        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        OptionsParser(db);

        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();
    }
    public void DequeueDialogue()
    {
        _audioSource.Play();
        textDisplayAnimator.SetBool("isPaused", false);

        if (_isCurrentlyTyping)
        {
            CompleteText();
            StopAllCoroutines();
            _isCurrentlyTyping = false;
            return;
        }

        if (dialogueInfo.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();

        
        _audioManager.Play(info.character.voice);

        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }
    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        OptionsLogic();
    }
    public void CloseOptions()
    {
        dialogueOptionsUI.SetActive(false);
    }
    #endregion
    #region Private Methods
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioManager = AudioManager.Instance;
    }
    private void DialogueSetter(DialogueBase.Info info)
    {
        dialogueName.text = info.character.name;
        completeText = info.sentence;
        dialogueText.text = info.sentence;
        dialogueText.font = info.character.font;
        info.ChangeEmotion();
        dialoguePortrait.sprite = info.character.Portrait;
    }
    private void OptionsLogic()
    {
        if (_isDialogueOption)
        {
            dialogueOptionsUI.SetActive(true);
        }
    }
    private void OptionsParser(DialogueBase db)
    {
        if (db is DialogueOptions)
        {
            _isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            _optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;

            // Clear previous buttons
            for (int i = 0; i < optionButtons.Length; i++)
                optionButtons[i].SetActive(false);

            for (int i = 0; i < _optionsAmount; i++)
            {
                optionButtons[i].SetActive(true);
                optionButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogueOptions.optionsInfo[i].optionText;
                OptionButtonEventHandler eventHandler = optionButtons[i].GetComponent<OptionButtonEventHandler>();
                eventHandler.buttonEventHandler = dialogueOptions.optionsInfo[i].optionEvent;

                // If there is a next dialogue to be triggered
                if (dialogueOptions.optionsInfo[i].nextDialogue != null)
                {
                    eventHandler.dialogue = dialogueOptions.optionsInfo[i].nextDialogue;
                }
                else
                {
                    eventHandler.dialogue = null;
                }
            }
        }
        else
        {
            _isDialogueOption = false;
        }
    }
    private void CompleteText()
    {
        dialogueText.text = completeText;
    }
    private bool CheckPunctuation(char c)
    {
        return punctuationCharacters.Contains(c) ? true : false;
    }
    #endregion

    // Coroutines
    IEnumerator TypeText(DialogueBase.Info info)
    {
        _isCurrentlyTyping = true;

        foreach(char c in info.sentence.ToCharArray())
        {
            yield return new WaitForSeconds(textSlowness);
            dialogueText.text += c;
            if (CheckPunctuation(c))
                yield return new WaitForSeconds(0.25f);
        }

        textDisplayAnimator.SetBool("isPaused", true);
        _isCurrentlyTyping = false;
    }
}
