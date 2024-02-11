/*****************************************************************************
// File Name :         RoomScript.cs
// Author :            Lorien Nergard
// Creation Date :     October 11th, 2023
//
// Brief Description : Controls how the spawning on doors works with each room.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public List<GameObject> roomEnemies;
    public List<GameObject> roomDoors;


    // Update is called once per frame
    void Update()
    {
        if (roomEnemies[0] == null & roomEnemies[1] == null & roomEnemies[2] == null & roomEnemies[3] == null
            & roomEnemies[4] == null & roomEnemies[5] == null & roomEnemies[6] == null & roomEnemies[7] == null)
        {

            for (int i = 0; i < roomDoors.Count; i++)
            {
                if (roomDoors[i] != null)
                    {
                        if (roomDoors[i].activeInHierarchy == false)
                        {
                            roomDoors[i].SetActive(true);
                        }
                }
            }
        }
    }
}
