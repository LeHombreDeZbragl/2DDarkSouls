using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private float pushingPower;

    private void Start()
    {
        pushingPower = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            other.gameObject.GetComponent<EveryLivingCreature>().health -= 3;
            PushingOthers(other.gameObject);
        }
    }

    private void PushingOthers(GameObject other)
    {
       other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position).normalized * pushingPower, ForceMode2D.Impulse);
    }
}
