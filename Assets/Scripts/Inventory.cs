using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Item> items = new List<Item>();
    private int maxSize = 2;

    public void AddItem(Item item)
    {
        if (IsFull())
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

    public bool IsFull()
    {
        return (items.Count >= maxSize);
    }

    public int Size() => items.Count;

}
