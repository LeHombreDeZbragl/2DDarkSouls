using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

    internal Rigidbody2D rb;
    [SerializeField] private GameObject dashEffect;

    float runSpeed = 3200f;
    float speed;

    float dashSpeed = 50000;
    float startTimeBtwDash = 1.4f;
    float timeBtwDash = 0;

    internal bool dashing = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.drag = 10;
        speed = runSpeed;
    }

    void Update()
    {
        if (dashing)
        {
            Instantiate(dashEffect, transform.position, Quaternion.identity);
        }
        MoveAndDash();
    }

    private void MoveAndDash()
    {
        if (inputManager.dashEnabled == true && timeBtwDash <= 0 && inputManager.movement != null)
        {
            speed = dashSpeed;
            timeBtwDash = startTimeBtwDash;
            dashing = true;

            Physics2D.IgnoreLayerCollision(8, 10);
            Physics2D.IgnoreLayerCollision(8, 9);

            Invoke("SpeedToNormal", 0.12f);

        }
        else
        {
            timeBtwDash -= Time.deltaTime;
        }
        inputManager.dashEnabled = false;
        rb.AddForce(inputManager.movement.normalized * speed * Time.deltaTime);
    }

    private void SpeedToNormal()
    {
        dashing = false;
        speed = runSpeed;

        Physics2D.IgnoreLayerCollision(8, 10, false);
        Physics2D.IgnoreLayerCollision(8, 9, false);

        rb.drag = 200f;
        Invoke("DragToNormal", 0.05f);
    }

    private void DragToNormal()
    {
        rb.drag = 10f;
    }
}
