using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNavigation : MonoBehaviour
{
    PlayerAction playerAction;
    AudioSource audioSource;

    [HideInInspector]
    public bool isSound = false;

    private void Start()
    {
        playerAction = GetComponent<PlayerAction>();
        audioSource = gameObject.transform.Find("Route Sound").GetComponent<AudioSource>(); 
    }


    private void FixedUpdate()
    {
        //not print && end move 
        if(!isSound && playerAction.isMove)
        {
            isSound = true;
            CheckRaycast();
        }


    }

    private void CheckRaycast()
    {
        if (playerAction.raycastUp.collider == null)
        {
            audioSource.Play();
        }
        else if (!playerAction.raycastUp.collider.CompareTag("BorderLine"))
        {
            playerAction.raycastUp.collider.GetComponent<AudioSource>().Play();
        }

        if (playerAction.raycastDown.collider == null)
        {

        }
    }

}
