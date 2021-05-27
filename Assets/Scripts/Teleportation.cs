using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Destination;

    public void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<CharacterController>();
        if (player)
        {
            StartCoroutine(Teleport(player));
        }
    }

    private IEnumerator Teleport(CharacterController controller)
    {
        yield return new WaitForSeconds(1.5f);
        controller.enabled = false;
        controller.transform.position = Destination.transform.position;
        controller.enabled = true;
    }
}
