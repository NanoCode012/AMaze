using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    private Animator animator;
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void Open()
    {
        animator.SetTrigger("open");
        boxCollider.enabled = false;
        // Play soundfx to opendoor;
    }

    private void OnTriggerEnter(Collider other)
    {
        Open();
    }
}
