using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Character Profile", menuName = "Characters/Profile", order = 1)]
public class CharacterProfile : ScriptableObject
{
    new public string name;
    public Sprite Portrait
    {
        get
        {
            SetEmotionType(Emotion);
            return _portrait;
        }
    }
    public AudioClip voice;
    public TMP_FontAsset font;

    private Sprite _portrait;

    [System.Serializable]
    public class EmotionPortraits
    {
        public Sprite standard;
        public Sprite happy;
        public Sprite angry;
        public Sprite sad;
    }

    public EmotionPortraits emotionPortraits;
    public EmotionType Emotion { get; set; }
    
    public void SetEmotionType(EmotionType newEmotion)
    {
        Emotion = newEmotion;
        switch (Emotion)
        {
            case EmotionType.Standard:
                _portrait = emotionPortraits.standard;
                break;
            case EmotionType.Happy:
                _portrait = emotionPortraits.happy;
                break;
            case EmotionType.Angry:
                _portrait = emotionPortraits.angry;
                break;
            case EmotionType.Sad:
                _portrait = emotionPortraits.sad;
                break;
        }
    }
}

public enum EmotionType
{
    Standard,
    Happy,
    Angry,
    Sad
}


