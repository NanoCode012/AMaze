using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void Open(GameObject objToSpawn)
    {
        animator.SetTrigger("open");
        boxCollider.enabled = false;
        StartCoroutine(SpawnRewardDelay(objToSpawn));
    }

    private IEnumerator SpawnRewardDelay(GameObject obj, float time = 2)
    {
        yield return new WaitForSeconds(time);
        Instantiate(obj, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
