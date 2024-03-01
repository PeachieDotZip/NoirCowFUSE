/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Harrison Weber
// Creation Date :     October 10th, 2023
//
// Brief Description : Controls many interactions in the game and keeps track of global variables.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerPos;
    public Animator canvasAnim;
    public int keyAmount;
    public GameObject[] endgameObjects;
    public AudioSource bgMusic;
    public GameObject bossMusic;
    public static bool usingController;
    public bool isMainMenu;

    private void Awake()
    {
        Time.timeScale = 1.0f;

        if (isMainMenu)
        {
            playerPos = null;
            canvasAnim = null;
            endgameObjects = null;
            bgMusic = null;
            bossMusic = null;
        }
        else
        {
            bgMusic = GetComponent<AudioSource>();
        }
    }

    public void CheckKeyAmount()
    {
        if (keyAmount == 3)
        {
            Destroy(endgameObjects[0]);
            endgameObjects[1].SetActive(true);
            endgameObjects[2].SetActive(true);
            //^^^ Bar gate and boss door
            //VVV Doors on the left and right
            //endgameObjects[3].SetActive(false);
            //endgameObjects[4].SetActive(false);
        }
    }

    public void ToggleControllerSupport()
    {
        if (usingController == false)
        {
            usingController = true;
            return;
        }
        if (usingController == true)
        {
            usingController = false;
            return;
        }
    }
}
