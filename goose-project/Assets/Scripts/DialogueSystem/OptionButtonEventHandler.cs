using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OptionButtonEventHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent buttonEventHandler;
    public DialogueBase dialogue;

    // This is what happens when you click on this button
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        buttonEventHandler.Invoke();
        DialogueManager.Instance.CloseOptions();
        
        if(dialogue != null)
        {
            DialogueManager.Instance.EnqueueDialogue(dialogue);
        }
    }
}
