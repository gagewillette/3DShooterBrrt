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
    
    private void Start()
    {
        
        ammoText = GetComponentInChildren<TextMeshProUGUI>();
    }

    //update ammo counter
    void Update()
    {
        String ammoString = $"{data.currentAmmo.ToString()} / {data.magSize.ToString()}";
        ammoText.text = ammoString;
    }
}
