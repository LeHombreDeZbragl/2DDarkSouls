using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour 
{
	internal string typeOfRoom;
	internal float enemiesChance = 4;
	internal bool spawnedEnemies = false;

	private RoomTemplates templates;

	private int rand;

	void Start()
	{
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(gameObject);
		templates.timeToLastRoom = 0.35f;

		if (templates.rooms.Count == 1)
		{
			typeOfRoom = "firstRoom";
		}
        else
        {
			Invoke("RoomAsign", 0.4f);
		}
	}

	private void RoomAsign()
    {
		if (gameObject == templates.rooms[templates.rooms.Count - 1])
		{
			typeOfRoom = "bossRoom";
			Instantiate(templates.boss, gameObject.transform.position, Quaternion.identity).transform.SetParent(transform);
		}
		else
		{
			rand = Random.Range(0, 15);

			if(rand <= templates.treasureRooms && templates.rooms.Count > 10)
            {
				templates.treasureRooms -= 1;
				typeOfRoom = "treasureRoom";
				Instantiate(templates.treasure, gameObject.transform.position, Quaternion.identity).transform.SetParent(transform);
			}
            else
            {
				typeOfRoom = "enemiesRoom";
				//Instantiate(templates.enemies, gameObject.transform.position, Quaternion.identity);
				Instantiate(templates.enemiesPattern, transform.position, templates.enemiesPattern.transform.rotation).transform.SetParent(transform);

				rand = Random.Range(0, templates.foregroundPatterns.Count);
				Instantiate(templates.foregroundPatterns[rand], transform.position, templates.foregroundPatterns[rand].transform.rotation).transform.SetParent(transform.Find("Walls"));
			}
		}
	}
}
