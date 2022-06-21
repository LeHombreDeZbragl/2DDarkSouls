using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] GameObject bulletBoom;

    private bool playerBullet = false;
    private int damage;
    private float recoilPower;
    private bool parried = false;

    private float speed;
    private float lifeTime;

    private bool guidedMissile = false;

    private GameObject player;
    private Rigidbody2D rb;

    private Transform originalShooter;
    private Transform follow;

    private Color azure;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(10, 10);

        originalShooter = transform.parent;
        azure = new Color(0, 1, 0.9f);
        lifeTime = 3;

        BulletType();

        BulletForce();

        Invoke("DestroyNotNow", lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            rb.velocity = Vector3.zero;
            if (!guidedMissile)
            {
                rb.AddForce((originalShooter.position - transform.position).normalized * speed, ForceMode2D.Impulse);
            }
            else if (guidedMissile)
            {
                rb.AddForce((originalShooter.position - transform.position).normalized * speed/200, ForceMode2D.Impulse);
                follow = originalShooter;
            }
            damage *= 2;
            gameObject.GetComponent<SpriteRenderer>().color = azure;
            playerBullet = true;
            other.GetComponent<Parry>().parry = true;
            parried = true;
            Invoke("DestroyNotNow", lifeTime);
        }
        else if (other.gameObject.CompareTag("Player") && !playerBullet)
        {
            other.gameObject.GetComponent<EveryLivingCreature>().health -= damage;
            DoingDmg(other.gameObject,true);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemies") && playerBullet)
        {
            other.gameObject.GetComponent<EveryLivingCreature>().health -= damage;
            other.gameObject.GetComponent<EnemyMovement>().externalVision = true;
            DoingDmg(other.gameObject,false);
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Walls") || 
            other.gameObject.CompareTag("Doors"))
        {
            Instantiate(bulletBoom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (originalShooter != null)
        {
            if (guidedMissile)
            {
                rb.AddForce((follow.position - transform.position).normalized * speed * Time.deltaTime);                
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void DestroyNotNow()
    {
        if (!parried)
        {
            Destroy(gameObject);
        }
        else
        {
            parried = false;
        }
    }

    private void BulletType()
    {
        if (gameObject.name == "WhatIsThisBullet(Clone)")
        {
            lifeTime = 0.3f;
            recoilPower = 7f;
            playerBullet = true;
            speed = 12f;
            damage = 4;
        }
        else if (gameObject.name == "SubmachineBullet(Clone)")
        {
            recoilPower = 1f;
            playerBullet = true;
            lifeTime = 0.4f;
            speed = 14f;
            damage = 1;
        }
        else if (gameObject.name == "ShotgunBullet(Clone)")
        {
            lifeTime = 0.3f;
            recoilPower = 3f;
            playerBullet = true;
            speed = 10f;
            damage = 1;
        }

        else if (gameObject.name == "NormalBullet(Clone)")
        {
            recoilPower = 5f;
            speed = 7f;
            damage = 2;
        }
        else if (gameObject.name == "ThiccBullet(Clone)")
        {
            recoilPower = 50f;
            speed = 22f;
            damage = 4;
        }
        else if (gameObject.name == "SmallBullet(Clone)")
        {
            recoilPower = 4f;
            speed = 1.8f;
            damage = 1;
        }
        else if (gameObject.name == "Rocket(Clone)")
        {
            rb.drag = 2f;
            recoilPower = 3f;
            speed = 3000f;
            lifeTime = 40f;
            damage = 4;
            guidedMissile = true;
            follow = player.transform;
        }
    }

    private void BulletForce()
    {
        if (playerBullet)
        {
            lifeTime = 1f;
            Vector3 rotation = (originalShooter.position - transform.position).normalized;
            if (gameObject.name == "ShotgunBullet(Clone)")
            {
                rotation *= 1000;
                rotation.x += Random.Range(-300, 300);
                rotation.y += Random.Range(-300, 300);
                speed = Random.Range(10, 16);
            }
            else if (gameObject.name == "SubmachineBullet(Clone)")
            {
                rotation *= 1000;
                rotation.x += Random.Range(-120, 120);
                rotation.y += Random.Range(-120, 120);
            }
            transform.parent.parent.parent.parent.GetComponent<PlayerMovement>().rb.AddForce(-rotation.normalized * recoilPower, ForceMode2D.Impulse);
            transform.SetParent(null);
            rb.AddForce(rotation.normalized * speed, ForceMode2D.Impulse);
        }
        else
        {
            transform.parent.parent.parent.GetComponent<EnemyMovement>().rb.AddForce(transform.right.normalized * recoilPower, ForceMode2D.Impulse);
            transform.SetParent(null);
            if (!guidedMissile)
            {
                rb.AddForce(-transform.right.normalized * speed, ForceMode2D.Impulse);
            }
        }
    }

    private void DoingDmg(GameObject other, bool player)
    {
        float power;
        if (player)
            power = 5f;
        else
            power = 5f;
        other.GetComponent<Rigidbody2D>().AddForce((other.gameObject.transform.position - transform.position).normalized * recoilPower * power, ForceMode2D.Impulse);
    }
}
