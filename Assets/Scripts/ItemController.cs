using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject HealthPrefab;
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

            var choicePrefab = GetRandomPrefab();
            if (choicePrefab != null) Instantiate(choicePrefab, obj.transform.position, Quaternion.identity);
        }

        Destroy(obj);

    }

    private GameObject GetRandomPrefab()
    {
        var choice = Random.Range(0, 2);
        switch (choice)
        {
            case 0:
                return HealthPrefab;
            case 1:
                return StaminaPrefab;
            default:
                return null;
        }
    }

    public void UseItem(PlayerController player, Item item)
    {
        switch (item.Type)
        {
            case Item.ItemType.HealthPotion:
                print("increased hp");
                player.Hp += 0.2f;
                break;
            case Item.ItemType.StaminaPotion:
                print("increased stamina");
                player.Stamina += 0.2f;
                break;
            default:
                break;
        }
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
