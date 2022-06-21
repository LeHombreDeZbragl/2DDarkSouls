using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] private GameObject exclamationMark;

    private Transform exclamationMarkPosition;
    private Vector3 eMPosWithY;
    private GameObject instantiatedExMark;
    private AnimationManager animator;

    internal bool fB = false;

    private float weaponLength;
    internal float charging;
    internal float startCharging;
    private bool parry = false;
    private float parryTime = 0f;

    internal bool ForB = true;
    internal bool rot = false;
    private bool attacking = false;
    private float attackDelay;
    private int damage;
    private float pushingPower;

    private void Start()
    {
        TypeOfWeapon();
        animator = transform.parent.GetComponent<AnimationManager>();
        exclamationMarkPosition = gameObject.transform.parent.parent.parent.transform;
        charging = startCharging;
    }

    private void Update()
    {
        ParryOnOfOff();
        if (!enemyMovement.stunned)
        {
            Attack();
            Invoke("Idle", 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            enemyMovement.stunnedTime += 1f;
            parryTime += 2f;
            transform.parent.parent.parent.GetComponent<EveryLivingCreature>().health -= damage * 2;
            PushingOthers(other.gameObject);
            other.GetComponent<Parry>().parry = true;
        }
        else if (other.gameObject.CompareTag("Player") && !parry && !other.gameObject.GetComponent<PlayerMovement>().dashing)
        {
            other.gameObject.GetComponent<EveryLivingCreature>().health -= damage;
            PushingOthers(other.gameObject);
        }
    }

    private void ParryOnOfOff()
    {
        if (parryTime > 0)
        {
            parry = true;
            parryTime -= Time.deltaTime;
        }
        else
        {
            parryTime = 0;
            parry = false;
        }
    }

    private void PushingOthers(GameObject other)
    {
        if (parry)
        {
            gameObject.transform.parent.parent.parent.GetComponent<Rigidbody2D>().AddForce(-(other.transform.position - transform.position).normalized * pushingPower, ForceMode2D.Impulse);
        }
        else
        {
            other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position).normalized * pushingPower, ForceMode2D.Impulse);
        }
    }

    private void TypeOfWeapon()
    {
        if (transform.name == "Cleaver")
        {
            weaponLength = 2f;
            startCharging = 1f;
            damage = 3;
            pushingPower = 10f;
        }
        else if (transform.name == "SledgeHammer")
        {
            weaponLength = 4f;
            startCharging = 2f;
            damage = 3;
            rot = true;
            pushingPower = 30f;
        }
        else if (transform.name == "Sword")
        {
            weaponLength = 3f;
            startCharging = 1.5f;
            damage = 2;
            pushingPower = 20f;
        }
        else if (transform.name == "Rapier")
        {
            weaponLength = 4f;
            startCharging = 2f;
            damage = 2;
            fB = true;
            pushingPower = 15f;
        }
    }

    private void Attack()
    {
        if (Vector2.Distance(transform.position, enemyMovement.playerPos.position) < 8)
        {
            if (charging <= 0)
            {
                if (Vector2.Distance(transform.position, enemyMovement.playerPos.position) < weaponLength)
                {
                    ExclamationMark();
                    Invoke("Smash", 0.3f);
                    charging = startCharging;
                }
            }
            else
            {
                charging -= Time.deltaTime;
            }
        }
    }

    private void ExclamationMark()
    {
        eMPosWithY = exclamationMarkPosition.position;
        eMPosWithY.y += 1f;
        instantiatedExMark = Instantiate(exclamationMark, eMPosWithY, Quaternion.identity);
        instantiatedExMark.transform.SetParent(exclamationMarkPosition);
    }

    private void DestroyExMark()
    {
        Destroy(instantiatedExMark);
    }

    private void Smash()
    {
        attacking = true;
        DestroyExMark();
        if (fB)
        {
            animator.ChangeAnimState("EnemyWeaponAnimFB");
            attackDelay = 0.5f;
        }
        else if (rot)
        {
            animator.ChangeAnimState("EnemyWeaponAnimRot");
            attackDelay = 1.2f;
        }
        else if (ForB)
        {
            animator.ChangeAnimState("EnemyWeaponAnimF");
            ForB = !ForB;
            attackDelay = 0.5f;
        }
        else
        {
            animator.ChangeAnimState("EnemyWeaponAnimB");
            ForB = !ForB;
            attackDelay = 0.5f;
        }
        Invoke("AttackComplete", attackDelay);
    }

    private void AttackComplete()
    {
        attacking = false;
    }

    private void Idle()
    {
        if (!attacking)
        {
            if (ForB)
                animator.ChangeAnimState("EnemyIdleAnimF");
            else
                animator.ChangeAnimState("EnemyIdleAnimB");
        }
    }
}