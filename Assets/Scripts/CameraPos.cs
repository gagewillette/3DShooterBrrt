using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}
