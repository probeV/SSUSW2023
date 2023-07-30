using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    PlayerAction playerAction;
    public AudioSource audioSource;

    bool isSound = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerAction = GetComponent<PlayerAction>();
    }

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        //not print && end move 
        if(!isSound && playerAction.isMove)
        {
            playerAction.raycastDown.collider.CompareTag("");
        }
    }

    private void CheckRaycast()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(""))

        if (collision.gameObject.CompareTag("Player"))
            audioSource.Play();
    }
}
