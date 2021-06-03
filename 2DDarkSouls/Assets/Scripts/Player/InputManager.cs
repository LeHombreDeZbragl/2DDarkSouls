using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    InputMaster input;

    internal Vector2 movement;
    internal Vector2 rotation;
    internal bool usingSWeapon;
    internal bool usingWeapon;
    internal bool dashEnabled;

    private void Awake()
    {
        input = new InputMaster();
    }

    void Update()
    {
        input.Gameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();

        input.Gameplay.Rotation.performed += ctx => rotation = ctx.ReadValue<Vector2>();

        input.Gameplay.Dash.performed += ctx => dashEnabled = true;

        input.Gameplay.PrimaryWeapon.performed += ctx => usingWeapon = true;

        input.Gameplay.SecondaryWeapon.performed += ctx => usingSWeapon = true;

        CheckIfSmall();
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

    private void OnEnable()
    {
        input.Gameplay.Enable();
    }
    private void OnDisable()
    {
        input.Gameplay.Disable();
    }
}
