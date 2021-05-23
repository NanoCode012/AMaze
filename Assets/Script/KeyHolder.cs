﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    private List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider collider)
    {
        bool e = Input.GetKeyDown(KeyCode.E);
        Key key = collider.GetComponent<Key>();
        if(key != null)
        {
            if(e){
                AddKey(key.GetKeyType());
                Destroy(key.gameObject);
            }
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
             
            }
        }
    }
}
