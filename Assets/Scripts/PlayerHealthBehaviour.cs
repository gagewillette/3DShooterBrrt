using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    [SerializeField] 
    private PlayerData data;

    private NewPlayerMovement move;
    public Transform orientation;
    void Start()
    {
        
        data.health = 100f;
    }

   
    void Update()
    {
        //DataUpdate();
        if (data.health > 0f)
        {
            PlayerDie();
            this.enabled = false;
        }
    }

    void PlayerDie()
    {
        move = GameObject.Find("Player").GetComponent<NewPlayerMovement>();
        move.enabled = false;
    }

    void DataUpdate()
    {
        data.position = orientation.position;
        data.rotation = orientation.rotation;
    }
}
