using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public struct Speaker
    {
        public string name;
        public Sprite sprite;
    }
    
    [System.Serializable]
    public struct DialogueElement
    {
        public Speaker speaker;
        [TextArea] public string sentence;
    }

    public DialogueElement[] dialogueElements;
}
