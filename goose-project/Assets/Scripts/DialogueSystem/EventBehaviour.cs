using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Dialogues/Event", order = 1)]
public class EventBehaviour : ScriptableObject
{
    public void TestEvent()
    {
        Debug.Log("Test event successful");

        // Any logic here will be fired off
    }

    public void TestEvent2()
    {
        Debug.Log("Test event 2 successful");
    }
    public void TestEvent3()
    {
        Debug.Log("Test event 3 successful");
    }

}
