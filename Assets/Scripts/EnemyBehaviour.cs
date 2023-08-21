using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //grab player transform for position calculation
    public GameObject player;

    // speed at which enemy moves towards player
    [SerializeField]
    private float speed = 20f;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player.IsUnityNull())
        {
            throw new NullReferenceException();
        }
    }

    void Update()
    {
        // check if player and enemy are roughly the same position
        if (Vector3.Distance(transform.position, player.transform.position) < .01f) return;
        
        //set step speed in respect to deltaTime
        float step = speed * Time.deltaTime;
        //update enemy position
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }


}
