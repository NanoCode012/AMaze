using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject HealthPrefab;
    public GameObject StaminaPrefab;

    private AudioController audioController;

    private void Start()
    {
        audioController = FindObjectOfType<AudioController>();
    }

    public void InteractItem(PlayerController player, GameObject obj)
    {
        if (!obj) return;
        if (obj.tag != "Item" && obj.transform.root.tag != "Item") return;

        var itemType = GetItemType(obj);

        bool destroyObjAtEnd = true;
        GameObject choicePrefab;

        switch (itemType)
        {
            case Item.ItemType.Key:
                print("picked up key");
                player.AddKey(new Item("Key", Item.ItemType.Key));
                audioController.PlayClip("pickupkey");
                break;
            case Item.ItemType.HealthPotion:
                print("picked up healthpotion");
                player.AddInventoryItem(new Item("Health potion", Item.ItemType.HealthPotion));
                audioController.PlayClip("itempickup");
                break;
            case Item.ItemType.StaminaPotion:
                print("picked up staminapotion");
                player.AddInventoryItem(new Item("Stamina potion", Item.ItemType.StaminaPotion));
                audioController.PlayClip("itempickup");
                break;
            case Item.ItemType.Crystal:
                print("Touched crystal");
                audioController.PlayClip("crystal");

                choicePrefab = GetRandomPrefab();
                if (choicePrefab != null) Instantiate(choicePrefab, obj.transform.position, Quaternion.identity);
                break;
            case Item.ItemType.Door:
                print("touch door");
                if (player.GotKey())
                {
                    audioController.PlayClip("door");
                    obj.GetComponent<Door>().Open();
                    player.RemoveKey();
                }
                else
                {
                    print("No key");
                }
                destroyObjAtEnd = false;
                break;
            case Item.ItemType.Lever:
                audioController.PlayClip("lever");
                obj.GetComponent<Lever>().Use();
                destroyObjAtEnd = false;
                break;
            case Item.ItemType.Button:
                audioController.PlayClip("button");
                obj.GetComponent<Button>().Use();
                destroyObjAtEnd = false;
                break;
            case Item.ItemType.Chest:
                audioController.PlayClip("chest");
                choicePrefab = GetRandomPrefab();
                obj.GetComponent<Chest>().Open(choicePrefab);
                destroyObjAtEnd = false;
                break;
        }

        if (destroyObjAtEnd) Destroy(obj);

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
                audioController.PlayClip("itemconsume");
                print("increased hp");
                player.Hp += 0.2f;
                break;
            case Item.ItemType.StaminaPotion:
                audioController.PlayClip("itemconsume");
                print("increased stamina");
                player.Stamina += 0.2f;
                break;
            case Item.ItemType.Key:
                // Check if got door
                // If no door, don't allow use
                break;
            default:
                break;
        }
    }

    public void SpawnItem(PlayerController player, Item item)
    {
        Instantiate(GetPrefab(item), new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z), Quaternion.identity);
    }

    public GameObject GetPrefab(Item item)
    {
        switch (item.Type)
        {
            case Item.ItemType.HealthPotion:
                return HealthPrefab;
            case Item.ItemType.StaminaPotion:
                return StaminaPrefab;
            default:
                return null;
        }
    }

    public bool UseDefaultMessage(PlayerController player, GameObject obj)
    {
        if (player.IsInventoryFull())
        {
            var type = GetItemType(obj);
            return (type != Item.ItemType.HealthPotion && type != Item.ItemType.StaminaPotion);
        }

        return true;
    }

    public Item.ItemType GetItemType(GameObject obj)
    {
        if (obj.GetComponent<Key>()) return Item.ItemType.Key;
        if (obj.GetComponent<Crystal>()) return Item.ItemType.Crystal;
        if (obj.GetComponent<HealthPotion>()) return Item.ItemType.HealthPotion;
        if (obj.GetComponent<StaminaPotion>()) return Item.ItemType.StaminaPotion;
        if (obj.GetComponent<Door>()) return Item.ItemType.Door;
        if (obj.GetComponent<Lever>()) return Item.ItemType.Lever;
        if (obj.GetComponent<Button>()) return Item.ItemType.Button;
        if (obj.GetComponent<Chest>()) return Item.ItemType.Chest;

        return Item.ItemType.None;
    }
}
