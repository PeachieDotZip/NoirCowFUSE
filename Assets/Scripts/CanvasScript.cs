/*****************************************************************************
// File Name :         CanvasScript.cs
// Author :            Harrison Weber
// Creation Date :     October 10th, 2023
//
// Brief Description : Contains the animation events to be used in sequences such as the player entering a door.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    private GameManager gameManager;
    private Animator UIanim;
    public GameObject newRoom;
    public float cameraSize;
    public Transform cameraPosition;
    private List<GameObject> roomEnemies;
    public Transform barTelepoint;
    public bool firstScene;
    public AudioSource scoreSound;
    public AudioSource scoreSoundFinal;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UIanim = GetComponent<Animator>();
    }

    private void Update()
    {
        UIanim.SetBool("FirstScene", firstScene);
    }

    /// <summary>
    /// Teleports player to next room and moves camera into position and scale.
    /// </summary>
    public void TeleportPlayer()
    {
        gameManager.playerPos.position = newRoom.transform.position;
        Camera.main.orthographicSize = cameraSize;
        Camera.main.transform.position = cameraPosition.position;
    }
    /// <summary>
    /// Teleports player back to main bar room. Also used when player collects key.
    /// </summary>
    public void RespawnPlayer()
    {
        CowHealthBehavior cowHealth = FindObjectOfType<CowHealthBehavior>();
        if (cowHealth.playerLives < 3)
        {
            cowHealth.playerLives = 3;
        }
        gameManager.playerPos.position = barTelepoint.position;
        Camera.main.orthographicSize = 17.2f;
        Camera.main.transform.position = barTelepoint.position;
    }
    /// <summary>
    /// 0 - small
    /// 1 - medium
    /// 2 - large
    /// </summary>
    /// <param name="size"></param>
    public void PlayScoreSound(int size)
    {
        switch (size)
        {
            case 0:
                scoreSound.volume = 0.3f;
                scoreSound.Play();
                break;
            case 1:
                scoreSound.volume = 0.9f;
                scoreSound.Play();
                break;
            case 2:
                scoreSoundFinal.Play();
                break;
            default:
                Debug.Log("I just shit myself");
                break;
        }
    }
    /// <summary>
    /// Returns the animator to idle, allowing the player to enter another door.
    /// </summary>
    public void EndDoorSequence()
    {
        UIanim.SetTrigger("ReturnToIdle");
    }
}
