using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
<<<<<<< Updated upstream

=======
    // Start is called before the first frame update
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        yield return new WaitForSeconds(1);
=======
        yield return new WaitForSeconds(1.5f);
>>>>>>> Stashed changes
        controller.enabled = false;
        controller.transform.position = Destination.transform.position;
        controller.enabled = true;
    }
}
