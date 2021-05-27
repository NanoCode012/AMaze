using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
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
        animator.SetTrigger("opendoor");
        boxCollider.enabled = false;
        Destroy(gameObject, 5f);
    }
}
