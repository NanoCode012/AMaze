using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{ 
public class KeyItemController : MonoBehaviour
{
        [SerializeField] private bool greenDoor = false;
        [SerializeField] private bool greenKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;
        
        private void Start()
        {
            if(greenDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if(greenDoor)
            {
                doorObject.PlayAnimation();
            }

            else if (greenKey)
            {
                _keyInventory.hasGreenKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
