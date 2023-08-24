using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GunPickupLogic : MonoBehaviour
{
    public GameObject player;
    private CapsuleCollider playerCollider;
    [SerializeField]
    private GameObject pistol;
    private Gun gun;
    
    
    private void Start()
    {
        gun = pistol.GetComponent<Gun>();
        playerCollider = player.GetComponentInChildren<CapsuleCollider>();
        Debug.Log(gun);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name.Equals("Capsule"))
        {
            pistol.SetActive(true);
            gun.hasGun = true;
            gameObject.SetActive(false);
        }
    }
}
