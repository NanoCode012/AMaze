using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
 
public class EnemyAI : MonoBehaviour {
 
    public Transform player; 
    private NavMeshAgent enemy; 
 
 
    // Use this for initialization
    void Start () {
         
 
        enemy = GetComponent<NavMeshAgent> ();
 
    }
     
    // Update is called once per frame
    void Update () {
 
        //enemy.SetDestination (player.position); 
        enemy.SetDestination(player.transform.position);
         
    }
}
