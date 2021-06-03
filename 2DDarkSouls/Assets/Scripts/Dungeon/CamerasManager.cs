using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    [SerializeField] GameObject CMcamera;

    private float time;
    internal bool playerIsSameRoom;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CMcamera.SetActive(true);
            time = 1.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CMcamera.SetActive(false);
            playerIsSameRoom = false;
            time = -1;
        }
    }

    private void Update()
    {
        if(time <= 1 && time > 0)
        {
            playerIsSameRoom = true;
        }
        else if(time > 1)
        {
            time -= Time.deltaTime;
        }
    }
}
