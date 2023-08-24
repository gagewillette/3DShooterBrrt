using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBounce : MonoBehaviour
{
    
    [SerializeField] private float speed = 3f;

    private Vector3 launch;
    private float distToGround = .5f;

    public Rigidbody rb;

    public float forceMultiplier = 10f;

    public bool grounded;
    private void Start()
    {
        
    }


    //launch enemy into air with a force and let gravity take over,
    // on landing, generate a new random vector 3 and then apply another force

    private void FixedUpdate()
    {
        if (!grounded) return;
    
        Vector3 randVec = RandVec3();
        Debug.Log(randVec);
        
        rb.AddForce(randVec * Time.deltaTime, ForceMode.Impulse);
        grounded = false;
    }
    
    //
    private Vector3 RandVec3()
    {
     return new Vector3(Random.Range(0, 360), Random.Range(0, 360), 20);
    }
    
    private void OnCollisionStay(Collision col)
    {
        if (col.collider.tag.Equals("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.tag.Equals("Ground"))
        {
            grounded = false;
        }
    }

}
