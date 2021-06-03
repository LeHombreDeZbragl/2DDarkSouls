using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if(_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }
    public GameObject normalBullet;
    public GameObject thiccBullet;
    public GameObject smallBullet;
    public GameObject rocket;

    public GameObject whatIsThisBullet;
    public GameObject submachineBullet;
    public GameObject shotgunBullet;

    public GameObject exclamationMark;
}