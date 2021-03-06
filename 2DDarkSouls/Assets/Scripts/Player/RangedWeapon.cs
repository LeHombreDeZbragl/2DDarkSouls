using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    float reload;
    float originalReload;    

    private WeaponSystem wSystem;
    private InputManager input;
    private GameObject bullet;

    [SerializeField] private GameObject whatIsThisBullet;
    [SerializeField] private GameObject submachineBullet;
    [SerializeField] private GameObject shotgunBullet;

    private Transform firePosition;

    private void Start()
    {
        wSystem = transform.parent.parent.GetComponent<WeaponSystem>();
        input = transform.parent.parent.parent.GetComponent<InputManager>();

        firePosition = transform.Find("ShotPoint");

        if (transform.name == "WhatIsThis")
        {
            bullet = whatIsThisBullet;
            originalReload = 0.4f;
        }
        else if (transform.name == "Submachine")
        {
            bullet = submachineBullet;
            originalReload = 0.022f;
        }
        else if (transform.name == "Shotgun")
        {
            bullet = shotgunBullet;
            originalReload = 0.5f;
        }
    }

    private void Update()
    {
        if (wSystem.fire)
        {
            Debug.Log("FIREE");
            reload = 0.5f;
        }
        if (reload >= 0)
        {
            if (transform.name == "Shotgun")
            {
                for (int i = 0; i < 18; i++)
                {
                    Fire();
                }
                wSystem.fire = false;
            }
            else
            {
                Fire();
                wSystem.fire = false;
            }
            reload -= originalReload;
        }
        else
        {
            reload = -1;
        }
    }

    private void Fire()
    {
        Instantiate(bullet, firePosition.position, transform.rotation).transform.SetParent(transform);
    }
}
