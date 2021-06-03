using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;

	private RoomTemplates templates;
	private int rand;
	private float waitTime = 6f;

	void Start()
	{
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", Random.Range(0.1f,0.3f));
	}

	void Spawn()
	{
		if(openingDirection == 0)
        {
			rand = Random.Range(0, templates.allRooms.Count);
			Instantiate(templates.allRooms[rand], transform.position, templates.allRooms[rand].transform.rotation);
		}

        else if (templates.roomsLimit)
        {
			if (openingDirection == 3)
			{
				Instantiate(templates.T, transform.position, templates.T.transform.rotation);
			}
            else if (openingDirection == 4)
            {
				Instantiate(templates.R, transform.position, templates.T.transform.rotation);
			}
			else if (openingDirection == 1)
			{
				Instantiate(templates.B, transform.position, templates.T.transform.rotation);
			}
            else
            {
				Instantiate(templates.L, transform.position, templates.T.transform.rotation);
			}
		}
        else
        {
			if (openingDirection == 1)
			{
				rand = Random.Range(0, templates.bottomRooms.Count);
				Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
			}
			else if (openingDirection == 2)
			{
				rand = Random.Range(0, templates.leftRooms.Count);
				Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
			}
			else if (openingDirection == 3)
			{
				rand = Random.Range(0, templates.topRooms.Count);
				Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
			}
			else if (openingDirection == 4)
			{
				rand = Random.Range(0, templates.rightRooms.Count);
				Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
			}
		}
		Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroyer"))
        {
			Destroy(gameObject);
        }
	}
}
