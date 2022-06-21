using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovement;

    private GameObject bullet;
    [SerializeField] private GameObject normalBullet;
    [SerializeField] private GameObject thiccBullet;
    [SerializeField] private GameObject smallBullet;
    [SerializeField] private GameObject rocket;

    [SerializeField] private GameObject exclamationMark;

    private Transform firePosition;
    private Transform exclamationMarkPosition;
    private Vector3 eMPosWithY;
    private GameObject instantiatedExMark;

    private float reloadTime;
    private float startingRealoadTime;
    private float littleMore;
    private float littleLess;
    private float randomizedTime;

    private void Start()
    {
        if (gameObject.name == "NormalGun")
        {
            startingRealoadTime = 3f;
            bullet = normalBullet;
        }
        else if (gameObject.name == "ThiccGun")
        {
            startingRealoadTime = 4f;
            bullet = thiccBullet;
        }
        else if (gameObject.name == "SmallGun")
        {
            startingRealoadTime = 2f;
            bullet = smallBullet;
        }
        else if (gameObject.name == "RocketGun")
        {
            startingRealoadTime = 6f;
            bullet = rocket;
        }
        randomizedTime = Random.Range(0, startingRealoadTime);
        reloadTime = randomizedTime;
        firePosition = transform.Find("ShotPoint");
        exclamationMarkPosition = gameObject.transform.parent.parent.transform;
    }

    private void Update()
    {
        if(bullet != null && enemyMovement.vision && !enemyMovement.stunned)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (reloadTime <= 0)
        {
            Invoke("Fire", 0.3f);
            ExclamationMark();
            Randomize();
        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
    }

    private void Fire()
    {
        Instantiate(bullet, firePosition.position, transform.rotation).transform.SetParent(gameObject.transform);
        DestroyExMark();
    }

    private void ExclamationMark()
    {
        eMPosWithY = exclamationMarkPosition.position;
        eMPosWithY.y += 1f;
        instantiatedExMark = Instantiate(exclamationMark, eMPosWithY, Quaternion.identity);
        instantiatedExMark.transform.SetParent(exclamationMarkPosition);
    }

    private void Randomize()
    {
        littleMore = startingRealoadTime + startingRealoadTime / 3;
        littleLess = startingRealoadTime - startingRealoadTime / 3;
        randomizedTime = Random.Range(littleLess, littleMore);
        reloadTime = randomizedTime;
    }

    private void DestroyExMark()
    {
        Destroy(instantiatedExMark);
    }
}