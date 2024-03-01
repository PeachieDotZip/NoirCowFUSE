using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineBehavior : MonoBehaviour
{
    private Animator anim;
    private AudioSource machineSFX;
    private UmbrellaBehaviour umbrella;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        machineSFX = GetComponent<AudioSource>();
        umbrella = FindObjectOfType<UmbrellaBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Umbrella"))
        {
            Debug.Log("Goober");
            if (umbrella.isPoking == true)
            {
                anim.SetTrigger("Poke");
                machineSFX.Play();
            }
        }
    }
}
