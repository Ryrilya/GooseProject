using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue Options", menuName = "Dialogues/Dialogue with Options", order = 1)]
public class DialogueOptions : DialogueBase
{
    [System.Serializable]
    public class Option
    {
        public string optionText;
        public DialogueBase nextDialogue;
        public UnityEvent optionEvent;
    }

    [TextArea(2, 10)] public string questionText;
    public Option[] optionsInfo;
}
