using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour 
{
	[SerializeField] EveryLivingCreature playerCreature;

	public List<GameObject> bottomRooms;
	public List<GameObject> topRooms;
	public List<GameObject> leftRooms;
	public List<GameObject> rightRooms;

	public List<GameObject> allRooms;

	public List<GameObject> rooms;
	internal float treasureRooms = 5;

	public GameObject boss;
	public GameObject enemies;
	public GameObject treasure;

	public GameObject T;
	public GameObject R;
	public GameObject B;
	public GameObject L;


	public List<GameObject> foregroundPatterns;
	public GameObject enemiesPattern;
	public List<GameObject> enemiesTypes;

	internal bool roomsLimit = false;
	internal bool lastRoom = false;
	internal float timeToLastRoom = 0.35f;
	private int timeToModify = 20;

    void Update()
	{
        if (!lastRoom)
        {
			isThisLastRoom();

			RoomLimit();
		}
        else
        {
			//Invoke("Reload", 0.2f);
        }
	}

	private void Reload()
    {
		//Debug.Log(rooms.Count);
		Debug.Log(treasureRooms);
		playerCreature.Reload();
	}

    private void ModifyGeneration()
    {
		if(rooms.Count > timeToModify)
        {
			for (int i = timeToModify; i < rooms.Count; i++)
			{
				bottomRooms.Add(bottomRooms[0]);
				topRooms.Add(topRooms[0]);
				leftRooms.Add(leftRooms[0]);
				rightRooms.Add(rightRooms[0]);
			}
			timeToModify = rooms.Count;
		}
	}

    private void isThisLastRoom()
	{
		if(timeToLastRoom <= 0)
        {
			lastRoom = true;
        }
        else
        {
			timeToLastRoom -= Time.deltaTime;
        }
    }

	private void RoomLimit() 
	{
		if(rooms.Count > timeToModify)
        {
			roomsLimit = true;
		}
	}
}
