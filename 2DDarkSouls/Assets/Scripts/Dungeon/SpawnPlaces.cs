using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaces : MonoBehaviour
{
	private RoomTemplates templates;
    private Transform player;
    private AddRoom room;
	private int rand;

    void Start()
	{
        room = transform.parent.parent.GetComponent<AddRoom>();
        player = GameObject.Find("Player").transform;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
	}

    private void OnTriggerStay2D(Collider2D other)
    {
		if (other.gameObject.CompareTag("Foreground"))
		{
			Destroy(gameObject);
		}		
    }

    private void Update()
    {
        if (Vector2.Distance(transform.parent.parent.position, player.position) < 20)
        {
            Invoke("Spawn", Random.Range(0.1f, 0.3f));

        }
    }

    private void Spawn()
    {
		rand = Random.Range(0, 75);
		if(rand <= room.enemiesChance)
        {
            room.enemiesChance -= 1;
			rand = Random.Range(0, templates.enemiesTypes.Count);
			Instantiate(templates.enemiesTypes[rand], transform.position, templates.enemiesTypes[rand].transform.rotation).transform.SetParent(transform.parent.parent.Find("Enemies"));
		}
        Invoke("SpawnedEnemies", 0.1f);
    }

    private void SpawnedEnemies()
    {
        room.spawnedEnemies = true;
        Destroy(gameObject);
    }
}