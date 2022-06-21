using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

    private void Update()
    {
        if (inputManager.rotation.x != 0 && inputManager.rotation.y != 0)
        {
            float angle = Mathf.Atan2(inputManager.rotation.x, inputManager.rotation.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }
    }
}
