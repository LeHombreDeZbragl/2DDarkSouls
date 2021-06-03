using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsBehaviour : MonoBehaviour
{
    public List<GameObject> doors;

    private GameObject enemies;
    private CamerasManager camerasManager;

    private AddRoom roomsManager;

    private float time = 0.6f;

    private void Start()
    {
        enemies = transform.parent.Find("Enemies").gameObject;
        camerasManager = transform.parent.Find("CamerasManager").gameObject.GetComponent<CamerasManager>();
        roomsManager = transform.parent.gameObject.GetComponent<AddRoom>();
    }

    private void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            ClosingDoors();
        }
    }

    private void ClosingDoors()
    {
        if (roomsManager.typeOfRoom == "enemiesRoom")
        {
            if (roomsManager.spawnedEnemies)
            {
                if (enemies.transform.childCount == 0)
                {
                    Destroy(gameObject);
                }

                if (camerasManager.playerIsSameRoom)
                {
                    foreach (GameObject door in doors)
                    {
                        door.SetActive(true);
                    }
                }
                else
                {
                    foreach (GameObject door in doors)
                    {
                        door.SetActive(false);
                    }
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
