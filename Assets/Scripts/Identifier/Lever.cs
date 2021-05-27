using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject target;

    private Animator animator;
    private Animator targetAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        targetAnimator = target.GetComponent<Animator>();
    }

    public void Use()
    {
        animator.SetTrigger("use");
        targetAnimator.SetTrigger("use");
    }
}
