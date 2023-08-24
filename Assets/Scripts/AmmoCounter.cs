using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField]
    private GunData data;
    [SerializeField] 
    private TextMeshProUGUI ammoText;

    [SerializeField]
    private Gun gun;
    private GameObject pistol;
    private void Start()
    {
        gun = pistol.GetComponent<Gun>();
        ammoText = GetComponentInChildren<TextMeshProUGUI>();
    }

    //update ammo counter
    void Update()
    {
        if (!gun.hasGun)
        {
            ammoText.text = "";
            return;
        }

        String ammoString = $"{data.currentAmmo.ToString()} / {data.magSize.ToString()}";
        ammoText.text = ammoString;
    }
}
