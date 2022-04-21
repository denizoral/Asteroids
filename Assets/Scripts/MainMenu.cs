using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Asteroids");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }

    public void showLeaderboard()
    {
        //TODO read a file and display results
    }

}