using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject HPPrefab;
    public GameObject StaminaPrefab;

    public void InteractItem(PlayerController player, GameObject obj)
    {
        if (!obj) return;

        var itemType = GetItemType(obj);

        if (itemType == Item.ItemType.Key)
        {
            print("picked up key");
            player.AddInventoryItem(new Item("Key", Item.ItemType.Key));
        }
        else if (itemType == Item.ItemType.HealthPotion)
        {
            print("picked up healthpotion");
            player.AddInventoryItem(new Item("Health potion", Item.ItemType.HealthPotion));
        }
        else if (itemType == Item.ItemType.StaminaPotion)
        {
            print("picked up staminapotion");
            player.AddInventoryItem(new Item("Stamina potion", Item.ItemType.StaminaPotion));
        }
        else if (itemType == Item.ItemType.Crystal)
        {
            print("Touched crystal");
            Instantiate(StaminaPrefab, obj.transform.position, Quaternion.identity);
        }

        Destroy(obj);

    }

    public Item.ItemType GetItemType(GameObject obj)
    {
        if (obj.GetComponent<Key>()) return Item.ItemType.Key;
        if (obj.GetComponent<Crystal>()) return Item.ItemType.Crystal;
        if (obj.GetComponent<HealthPotion>()) return Item.ItemType.HealthPotion;
        if (obj.GetComponent<StaminaPotion>()) return Item.ItemType.StaminaPotion;

        return Item.ItemType.None;
    }
}
