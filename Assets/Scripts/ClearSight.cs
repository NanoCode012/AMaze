using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSight : MonoBehaviour
{
    private float DistanceToPlayer;

    private void Start()
    {
        DistanceToPlayer = GetComponent<CameraController>().GetCameraDistance();
    }

    void Update()
    {
        RaycastHit[] hits;
        // you can also use CapsuleCastAll()
        // TODO: setup your layermask it improve performance and filter your hits.
        hits = Physics.RaycastAll(transform.position, transform.forward, DistanceToPlayer);
        foreach (RaycastHit hit in hits)
        {
            Renderer R = hit.collider.GetComponent<Renderer>();
            if (R == null)
                continue; // no renderer attached? go to next hit
            // TODO: maybe implement here a check for GOs that should not be affected like the player
            if (hit.collider.transform.root.tag == "Trap")
                continue;

            AutoTransparent AT = R.GetComponent<AutoTransparent>();
            if (AT == null) // if no script is attached, attach one
            {
                AT = R.gameObject.AddComponent<AutoTransparent>();
            }
            AT.BeTransparent(); // get called every frame to reset the falloff
        }
    }
}
