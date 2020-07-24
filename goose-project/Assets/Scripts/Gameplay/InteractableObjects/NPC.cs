using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public Dialogue dialogue;

    private Player _player;

    private void Start()
    {
        _player = Player.Instance;
    }

    public override void Interact()
    {
        base.Interact();

        // Debug.Log("Interacting with NPC (" + gameObject.name + ").");
        var patrolFreedom = GetComponent<PatrolFreedom>();
        var patrolWithSpots = GetComponent<PatrolWithSpots>();

        if (patrolFreedom != null)
            patrolFreedom.enabled = false;
        if (patrolWithSpots != null)
            patrolWithSpots.enabled = false;

        // Open dialogue system if the NPC has dialogues
        if(dialogue != null)
            DialogueSystem.Instance.OpenDialogue(dialogue);
        // Make the NPC look at the player
        transform.LookAt(_player.transform);
        // Make the Player look at the NPC
        _player.transform.LookAt(transform);
    }
}
