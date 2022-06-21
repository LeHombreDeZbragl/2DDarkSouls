    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapon : MonoBehaviour
{
    private void Awake()
    {
        int i = transform.childCount;
        int j = Random.Range(0,i);
        transform.GetChild(j).gameObject.SetActive(true);
    }
}
