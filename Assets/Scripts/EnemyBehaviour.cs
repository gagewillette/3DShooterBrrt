using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //grab player transform for position calculation
    public Transform player;

    // speed at which enemy moves towards player
    public float speed = 1f;
    
    void Update()
    {
        // check if player and enemy are roughly the same position
        if (Vector3.Distance(transform.position, player.position) < .01f) return;
        
        //set step speed in respect to deltaTime
        float step = speed * Time.deltaTime;
        //update enemy position
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
    }


}
