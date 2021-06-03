using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Difficulty(int difficulty)
    {
        if(difficulty == 0)
        {

        }
        else if (difficulty == 1)
        {

        }
        else if (difficulty == 2)
        {

        }
    }
}
