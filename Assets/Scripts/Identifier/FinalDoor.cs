using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    private Animator animator;
    private BoxCollider boxCollider;
    private AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType<AudioController>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void Open()
    {
        animator.SetTrigger("open");
        boxCollider.enabled = false;
        audioController.PlayClip("final");
        // Play soundfx to opendoor;
    }

    private void OnTriggerEnter(Collider other)
    {
        Open();
    }
}
