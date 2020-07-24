using System;
using UnityEngine;

public class PickupItem : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool isPickedUp = Inventory.Instance.Add(item);
        if (isPickedUp)
        {
            Destroy(gameObject);
            // Check if object is required by any player's quests
            QuestManager.Instance.CheckItemGathered(item);
        }
    }
}
