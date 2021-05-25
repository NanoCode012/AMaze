using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items;
    private int maxSize = 2;

    private void Start()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (items.Count > maxSize)
        {
            throw new System.Exception("Cannot add. Inventory full");
        }
        items.Add(item);
    }

    public Item Pop()
    {
        var item = items[0];
        items.RemoveAt(0);
        return item;
    }

    public IEnumerable<string> GetInventory()
    {
        return items.Select(item => item.Name);
    }

}
