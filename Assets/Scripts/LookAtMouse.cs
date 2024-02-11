/*****************************************************************************
// File Name :         LookAtMouse.cs
// Author :            Harrison Weber
// Creation Date :     September 21st, 2023
//
// Brief Description : Rotates the game object towards the mouse on the screen.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    public GameObject cow;
    private CowController cowController;
    public CowHealthBehavior cowHealth;
    public bool canLook;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        cowController = FindObjectOfType<CowController>();
    }

    /// <summary>
    /// Update the rotation of the object to face the position of the mouse;
    /// </summary>
    private void Update()
    {
        if (canLook == true)
        {
            gameObject.transform.position = cow.transform.position;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        }
        anim.SetBool("dead", cowController.isDead);
    }

    public void HurtInvuln_On()
    {
        cowHealth.isInvulnerable = true;
    }
    public void HurtInvuln_Off()
    {
        cowHealth.isInvulnerable = false;
    }
}
