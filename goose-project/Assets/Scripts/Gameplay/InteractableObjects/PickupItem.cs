using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickupItem : Interactable
{
    public Item item;

    private MouseControl _mouseControl;

    private void Start()
    {
        _mouseControl = UIManager.Instance.GetComponent<MouseControl>();
    }

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

    private void OnMouseEnter()
    {
        _mouseControl.Pickup();
    }

    private void OnMouseExit()
    {
        _mouseControl.Default();
    }
}
