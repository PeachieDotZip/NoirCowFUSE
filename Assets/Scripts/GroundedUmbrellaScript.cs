using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedUmbrellaScript : MonoBehaviour
{
    public GameObject umbrella;
    public GameObject mosTutorials;
    public GameObject conTutorials;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            umbrella.SetActive(true);
            Destroy(gameObject);
            if (GameManager.usingController)
            {
                conTutorials.SetActive(true);
            }
            else
            {
                mosTutorials.SetActive(true);
            }
        }
    }
}
