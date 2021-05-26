using System.Collections;
using System.Collections.Generic;

public class Item
{
    public enum ItemType
    {
        None,
        Key,
        HealthPotion,
        StaminaPotion,
        Crystal,
        Door,
        Lever,
    }

    public string Name { get; set; }
    public ItemType Type { get; set; }

    public Item(string name, ItemType type)
    {
        Name = name;
        Type = type;
    }
}
