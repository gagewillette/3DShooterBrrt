using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Gun : MonoBehaviour
{
    [SerializeField] public GunData data;

    private float timeSinceLastShot;
    public Transform muzzle;

    public void StartReload()
    {
        if (!data.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        data.reloading = true;

        yield return new WaitForSeconds(data.reloadTime);

        data.currentAmmo = data.magSize;

        data.reloading = false;
    }

    private void Start()
    {
        //actions
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    private bool CanShoot() => !data.reloading && timeSinceLastShot > 1 / (data.fireRate / 60);

    public void Shoot()
    {
        if (data.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, data.maxDistance))
                {
                    
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.Damage(data.damage);
                }
                
                data.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(muzzle.position, muzzle.forward);
    }

    private void OnGunShot()
    {
        //particles
        //actual visualization
    }
}