using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EveryLivingCreature : MonoBehaviour
{
    [SerializeField] private GameObject bloodSplash;
    [SerializeField] private GameObject royalBloodSplash;
    private EnemyMovement enemyMovement;

    internal int health;
    private int currentHealth;
    float shakingPower;

    private void Start()
    {
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        if (gameObject.CompareTag("Player"))
        {
            health = 20;
        }
        else if (gameObject.CompareTag("Enemies"))
        {
            health = 8;
            if (enemyMovement.isMelee)
            {
                health = 12;
            }
        }
        currentHealth = health;
    }

    private void LateUpdate()
    {
        if (health <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                Reload();
            }
            else
            {
                Destroy();
            }
        }

        if (health < currentHealth)
        {
            shakingPower = currentHealth - health;
            if (gameObject.CompareTag("Player"))
            {
                //CameraShaker.Instance.ShakeOnce(shakingPower + 3, shakingPower + 2, 0.06f, 0.06f);
                Instantiate(royalBloodSplash, transform.position, Quaternion.identity);
            }
            else
            {
                //CameraShaker.Instance.ShakeOnce(shakingPower, shakingPower, 0.04f, 0.04f);
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
            }
        }
        currentHealth = health;
    }

    private void Destroy()
    {
         Destroy(gameObject);
    }

    internal void Reload()
    {
         SceneManager.LoadScene(0);
    }
}
