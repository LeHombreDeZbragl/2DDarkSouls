using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

    private GameObject primaryWeapon;
    private GameObject secondaryWeapon;
    private GameObject tertiaryWeapon;

    float reloadS;
    float reloadT;
    float originalReload;

    internal bool again;
    internal bool fire;

    private void Start()
    {
        reloadS = 0f;
        reloadT = 0f;
        originalReload = 1f;

        primaryWeapon = transform.Find("PrimaryWeapon").gameObject;
        secondaryWeapon = transform.Find("SecondaryWeapon").gameObject;
        tertiaryWeapon = transform.Find("TertiaryWeapon").gameObject;
        WeaponsDownS();
        WeaponsDownT();
    }

    private void Update()
    {
        UsingSWeapon();
    }
    private void UsingSWeapon()
    {
        reloadS -= Time.deltaTime;

        if (inputManager.usingSWeapon == true && reloadS <= 0)
        {
            reloadS = originalReload;

            fire = true;
            primaryWeapon.SetActive(false);
            secondaryWeapon.SetActive(true);

            Invoke("WeaponsDownS", 0.5f);

            return;
        }        
    }

    private void WeaponsDownS()
    {
        fire = false;
        primaryWeapon.SetActive(true);
        secondaryWeapon.SetActive(false);
    }

    private void WeaponsDownT()
    {
        primaryWeapon.SetActive(true);
        tertiaryWeapon.SetActive(false);
    }
}
