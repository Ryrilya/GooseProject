using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [Header("Cursor Textures")]
    public Texture2D cursorDefault;
    public Texture2D cursorPickup;
    public Texture2D cursorSpeak;

    void Start()
    {
        Default();
    }

    public void Default()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Pickup()
    {
        Cursor.SetCursor(cursorPickup, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Speak()
    {
        Cursor.SetCursor(cursorSpeak, Vector2.zero, CursorMode.ForceSoftware);
    }
}
