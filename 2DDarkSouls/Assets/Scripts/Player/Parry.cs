using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    internal bool parry = false;

    [SerializeField] private GameObject parrryEffect;

    private void Update()
    {
        if (parry)
        {
            playParry();
        }
    }

    internal void playParry()
    {
        transform.parent.parent.GetComponent<WeaponSystem>().again = true;
        Instantiate(parrryEffect, transform.position, Quaternion.identity);
        //CameraShaker.Instance.ShakeOnce(2, 3, 0.04f, 0.04f);
        parry = false;
    }
}
