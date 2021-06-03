using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegroupingEnemies : MonoBehaviour
{
    private GameObject player;
    internal Rigidbody2D rb;

    public GameObject[] enemies;

    private Vector3 playerPos;
    private Vector2 playerPos2;
    private Vector2 moveToSide;

    private float degroupDistance;
    private float randomSpeed;
    private float startChangingDirectionTime;
    private float changingDirectionTime;
    private bool tooClose = false;
    private bool randomBool;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        enemies = GameObject.FindGameObjectsWithTag("Enemies");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == gameObject)
            {
                enemies[i] = null;
            }
        }

        playerPos = player.transform.position;
        playerPos2 = playerPos;
        degroupDistance = 1.3f;
        startChangingDirectionTime = 0.5f;
        changingDirectionTime = startChangingDirectionTime;

        if (Random.Range(0, 2) == 0)
            randomBool = true;
        else
            randomBool = false;
        randomSpeed = Random.Range(300, 600);
    }

    private void Update()
    {
        playerPos = player.transform.position;
        playerPos2 = playerPos;
        if (player != null)
        {
            Degrouping();
        }

        if (changingDirectionTime <= 0)
        {
            if (Random.Range(0, 2) == 0)
                randomBool = true;
            else
                randomBool = false;
            changingDirectionTime = startChangingDirectionTime;
        }
        else
        {
            changingDirectionTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Foreground"))
        {
            if (randomBool)
                randomBool = false;
            else
                randomBool = true;
        }
        else if (other.gameObject.CompareTag("Enemies"))
        {
            if (Random.Range(0, 2) == 0)
                randomBool = true;
            else
                randomBool = false;
        }
    }

    private void Degrouping()
    {
        tooClose = false;

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                if (Vector2.Distance(transform.position, enemies[i].transform.position) < degroupDistance)
                {
                    tooClose = true;
                }
            }
        }

        if (tooClose)
        {
            if (randomBool)
            {
                moveToSide.x = ((Vector2)transform.position - playerPos2).y;
                moveToSide.y = -((Vector2)transform.position - playerPos2).x;
            }
            else
            {
                moveToSide.x = -((Vector2)transform.position - playerPos2).y;
                moveToSide.y = +((Vector2)transform.position - playerPos2).x;
            }
            rb.AddForce(moveToSide.normalized * randomSpeed * Time.deltaTime);
        }
    }
}