using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private WeaponBehaviour weaponBehaviour;

    public bool isMelee = false;
    public bool sledge = false;
    public bool sword = false;
    public bool rapier = false;
    public bool cleaver = false;

    private GameObject player;
    private Color startingColor;
    private GameObject camerasManager;

    internal Rigidbody2D rb;
    internal Transform playerPos;

    private float speed;
    private float panickDistance;
    private float cockyDistance;
    private float timeToDash = 8f;

    internal bool vision;
    internal bool externalVision = false;
    internal bool stunned = false;
    internal float stunnedTime = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        camerasManager = transform.parent.parent.Find("CamerasManager").gameObject;
        startingColor = gameObject.GetComponent<SpriteRenderer>().color;

        playerPos = player.transform;
        rb.drag = 10f;
        speed = 1000;

        vision = false;

        cockyDistance = 10;
        panickDistance = 5;

        TypeOfWeapon();
    }

    private void Update()
    {
        if (camerasManager.GetComponent<CamerasManager>().playerIsSameRoom)
        {
            vision = true;
        }

        if (vision && !stunned && isMelee && Vector2.Distance(transform.position, playerPos.position) > 6)
        {
            if (timeToDash <= 0)
            {
                timeToDash = 8f;
                Dashing();
            }
            else
            {
                timeToDash -= Time.deltaTime;
            }
        }

        if (stunnedTime > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            stunned = true;
            stunnedTime -= Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = startingColor;
            stunnedTime = 0f;
            stunned = false;
        }
    }

    private void FixedUpdate()
    {
        if (player != null && vision && !stunned)
        {
            Moving();
        }
    }
    
    private void TypeOfWeapon()
    {
        if (isMelee)
        {
            if (sledge)
            {
                cockyDistance = 2.5f;
                panickDistance = 2f;
                speed = 2500f;
            }
            else if (rapier)
            {
                cockyDistance = 3.2f;
                panickDistance = 2.7f;
                speed = 2500f;
            }
            else if (cleaver)
            {
                speed = 4000;
                cockyDistance = 1.5f;
                panickDistance = 0.5f;
            }
            else if (sword)
            {
                speed = 3000;
                cockyDistance = 2.5f;
                panickDistance = 2f;
            }
        }
    }

    private void Dashing()
    {
        transform.position = playerPos.position + transform.position /30;
        weaponBehaviour.charging = weaponBehaviour.startCharging/3;
    }

    private void Moving()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < panickDistance)
        {
            rb.AddForce(((Vector2)transform.position - (Vector2)playerPos.position).normalized * speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, playerPos.position) > cockyDistance)
        {
            rb.AddForce(((Vector2)transform.position - (Vector2)playerPos.position).normalized * -speed * Time.deltaTime);
        }
    }
}