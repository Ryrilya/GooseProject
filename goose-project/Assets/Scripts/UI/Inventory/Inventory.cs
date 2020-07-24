using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory>
{
    public List<Item> items = new List<Item>();
    public int space = 20;
    public delegate void OnItemChanged();
    public delegate void ItemEventHandler(Item item);
    public OnItemChanged onItemChangedCallback;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space in the inventory!");
                return false;
            }

            items.Add(item);
            onItemChangedCallback?.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        onItemChangedCallback?.Invoke();
    }
}
