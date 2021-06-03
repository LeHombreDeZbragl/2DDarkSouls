using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovement;

    private GameObject player;
    private Vector2 rotation;
    private Transform playerPos;
    [SerializeField] private WeaponBehaviour weaponBehaviour;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform;
    }

    private void Update()
    {
        if(player != null && enemyMovement.vision && !enemyMovement.stunned)
        {
            RotateToPlayer();
        }
    }

    private void RotateToPlayer()
    {
        rotation = playerPos.position - transform.position;

        float angle = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        if (enemyMovement.isMelee)
        {
            if (weaponBehaviour.fB)
            {
                angle -= 90;
            }
        }
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.back);
    }
}