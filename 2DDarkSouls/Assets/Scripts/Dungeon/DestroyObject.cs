using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private bool child = true;

    private void Start()
    {
        if (gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject, 4f);
            child = false;
        }
    }

    private void Update()
    {
        if (child)
        {
            if(gameObject.transform.childCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
