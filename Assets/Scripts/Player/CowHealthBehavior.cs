/*****************************************************************************
// File Name :         CowHealthBehavior.cs
// Author :            Lorien Nergard
// Creation Date :     October 16th, 2023
//
// Brief Description : Controls the health, lives, and respawn of the cow
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization;
using UnityEngine.Profiling;
using UnityEngine.Rendering.PostProcessing;

public class CowHealthBehavior : MonoBehaviour
{
    public float playerLives;
    public bool isInvulnerable;
    public GameObject youDied;
    public GameObject restartButton;
    public GameObject exitButton;
    public GameObject mainMenu;
    public UmbrellaBehaviour umbrella;
    public Animator cowAnim;
    //public TextMeshProUGUI livesText;
    private AudioSource damageSFX;
    public AudioSource collectSFX;
    private CowController cowController;
    public PostProcessProfile profile;
    private AudioListener listener;
    public Animator canvasAnim;

    public static float currentScore;
    public TextMeshProUGUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = 3;
        currentScore = 000;

        youDied.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        mainMenu.SetActive(false);
        damageSFX = GetComponent<AudioSource>();
        cowController = GetComponent<CowController>();
        listener = FindObjectOfType<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + currentScore.ToString();

        if (playerLives > 0)
        {
            //livesText.text = "Lives : " + playerLives.ToString();
        }      
        else 
        {
            youDied.SetActive(true);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
            mainMenu.SetActive(true);
            cowController.isDead = true;
            profile.GetSetting<ColorGrading>().saturation.value = -100f;
            profile.GetSetting<ColorGrading>().contrast.value = 60f;
            Time.timeScale = 0.1f;
            canvasAnim.SetBool("ko", true);
            //cowdead anim
        }
        if (playerLives > 3)
        {
            playerLives = 3;
        }
        if(currentScore <= 0)
        {
            currentScore = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && umbrella.isBashing == false)
        {
            TakeDamage(50);
        }
        if (collision.CompareTag("Key"))
        {
            collectSFX.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Enemy_Charging")) && umbrella.isBashing == false)
        {
            TakeDamage(40);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (isInvulnerable == false)
        {
            damageSFX.Play();
            cowAnim.SetTrigger("hurt");
            currentScore -= damageAmount;
            Debug.Log("Cow Noir took damage!");
        }
    }
}
