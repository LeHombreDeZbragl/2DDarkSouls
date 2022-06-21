using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    internal Vector2 movement;
    internal Vector2 rotation;
    internal bool usingWeapon;
    internal bool usingSWeapon;
    internal bool usingTWeapon;
    internal bool dashEnabled;

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));

        rotation = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));

        if(rotation == Vector2.zero)
        {
            Vector2 mousePos = Input.mousePosition;
            rotation = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        }

        

        dashEnabled = Input.GetAxis("Jump") > 0;

        usingSWeapon = Input.GetAxis("Fire2") > 0;

        usingTWeapon = Input.GetAxis("Fire1") > 0;

        //CheckIfSmall();
    }

    private void CheckIfSmall()
    {
        if (movement.magnitude < 0.5)
        {
            movement = Vector2.zero;
        }
        if (rotation.magnitude < 0.5)
        {
            rotation = Vector2.zero;
        }
    }
}
