using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[System.Serializable]
[CreateAssetMenu(fileName = "New Goose", menuName = "Goose")]
public class Goose : ScriptableObject
{
    [Header("General information")]
    public new string name;
    [TextArea(3, 10)] public string lore;
    [Header("GFX")]
    public Sprite sprite;
    public GameObject modelFBX;


    public Vector3 rotation = new Vector3();
    public Vector3 scale = new Vector3();
    public Vector3 cameraOffset = new Vector3();
    

    // particellari
    // abilità uniche
    // suoni
}
