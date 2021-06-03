using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

    private GameObject primaryWeapon;
    private GameObject secondaryWeapon;

    float reload;
    float originalReload;

    internal bool again;
    internal bool fire;

    private void Start()
    {
        reload = 0f;
        originalReload = 1f;

        primaryWeapon = transform.Find("PrimaryWeapon").gameObject;
        secondaryWeapon = transform.Find("SecondaryWeapon").gameObject;

        WeaponsDown();
    }

    private void Update()
    {
        UsingWeapon();
    }

    private void UsingWeapon()
    {
        fire = false;

        if (inputManager.usingSWeapon == true)
        {
            if (again || reload <= 0)
            {
                again = false;

                reload = originalReload;

                fire = true;
                primaryWeapon.SetActive(false);
                secondaryWeapon.SetActive(true);

                Invoke("WeaponsDown", 0.5f);
            }
        }
        reload -= Time.deltaTime;

        inputManager.usingWeapon = false;
        inputManager.usingSWeapon = false;
    }

    private void WeaponsDown()
    {
        primaryWeapon.SetActive(true);
        secondaryWeapon.SetActive(false);
    }
}
