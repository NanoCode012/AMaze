using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject HPPrefab;
    public GameObject StaminaPrefab;

    public void InteractItem(PlayerController player, GameObject obj, Item.ItemType itemType)
    {
        if (!obj) return;

        Destroy(obj);

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
        else if (itemType == Item.ItemType.Crystal)
        {
            Instantiate(HPPrefab, transform.position, Quaternion.identity);
        }

    }
}
