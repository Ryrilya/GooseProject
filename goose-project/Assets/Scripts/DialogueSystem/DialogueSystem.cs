using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoSingleton<DialogueSystem>
{
    [Header("References")]
    public GameObject dialogueBox;
    public Image speakerAvatar;
    public TextMeshProUGUI textSpeaker;
    public TextMeshProUGUI textDisplay;
    public GameObject continueButton;
    public Animator textDisplayAnimator;

    [Header("Settings")]
    public float typingSpeed;

    // Event
    public event System.Action OnDialogueClose;


    private int _index = 0;
    private AudioSource _source;
    private Dialogue _dialogue = null;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(_dialogue != null)
            if (textDisplay.text == _dialogue.dialogueElements[_index].sentence)
                continueButton.SetActive(true);           
    }

    public void OpenDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        _dialogue = dialogue;
        StartCoroutine(Type());
    }

    public void CloseDialogue()
    {
        dialogueBox.SetActive(false);
        OnDialogueClose?.Invoke();
    }

    public void NextSentence()
    {
        _source.Play();
        textDisplayAnimator.SetTrigger("Change");
        continueButton.SetActive(false);

        // Dialogue still has sentences to display
        if(_index < _dialogue.dialogueElements.Length - 1)
        {
            _index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        // Dialogue is ended
        else
            CloseDialogue();
    }

    IEnumerator Type()
    {
        speakerAvatar.sprite = _dialogue.dialogueElements[_index].speaker.sprite;
        textSpeaker.text = _dialogue.dialogueElements[_index].speaker.name;

        foreach (char letter in _dialogue.dialogueElements[_index].sentence.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
