using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTSpanwerBehav : MonoBehaviour
{
    public GameObject spawner;
    public GameObject fab;
    
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(fab, spawner.transform.position, spawner.transform.rotation);
        }
    }
    
}
