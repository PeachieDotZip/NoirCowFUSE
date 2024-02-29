/*****************************************************************************
// File Name :         MainMenu.cs
// Author :            Lorien Nergard
// Creation Date :     October 16th, 2023
//
// Brief Description : Controls the buttons on the main menu
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Sets time scale back to 1
    /// </summary>
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    /// <summary>
    /// Quits the game
    /// </summary>
    public void exitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Goes to the fusr first iteration
    /// </summary>
    public void playGame()
    {
        SceneManager.LoadScene("FuseFirstIteration");
    }
}
