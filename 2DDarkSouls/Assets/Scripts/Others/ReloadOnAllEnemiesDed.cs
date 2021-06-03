using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnAllEnemiesDed : MonoBehaviour
{
    private GameObject enemies;

    private void Start()
    {
        enemies = GameObject.Find("Enemies");
    }

    private void Update()
    {
        if(enemies.transform.childCount == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
