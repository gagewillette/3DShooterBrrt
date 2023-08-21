using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Transactions;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CamMove : MonoBehaviour
{
    public Transform trans;
    public float speedModifier = 3f;
    
    void Start()
    {
        trans = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        trans.position += Vector3.back * Time.deltaTime * speedModifier;
    }
}
