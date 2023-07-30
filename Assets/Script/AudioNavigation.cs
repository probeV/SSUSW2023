using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

static class Constants
{
    public const int UP = 0;
    public const int DOWN = 1;
    public const int LEFT = 2;
    public const int RIGHT = 3;
    public const int PATH = 4;
    public const int WALL = 5;
}

public class AudioNavigation : MonoBehaviour
{
 
    AudioSource[] audioSources;

    AudioManager audioManager;
    PlayerAction playerAction;

    private void Awake()
    {
        playerAction = GetComponent<PlayerAction>();

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioSources = audioManager.transform.Find("NaviSound").GetComponentsInChildren<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (audioManager.isNaviSound)
        {
            audioManager.isNaviSound = false;
            NaviSound();
        }
    }

    private void NaviSound()
    {
        //Up
        if (playerAction.raycastUp.collider == null)
        {
            audioSources[Constants.UP].Play();
            audioSources[Constants.PATH].Play();
        }
        else if (!playerAction.raycastUp.collider.CompareTag("BorderLine"))
        {
            audioSources[Constants.UP].Play();
            playerAction.raycastUp.collider.GetComponent<AudioSource>().Play();
        }
       
        ////Down
        //if (playerAction.raycastDown.collider == null)
        //{
        //    audioSources[Constants.DOWN].Play();
        //    audioSources[Constants.PATH].Play();
        //}
        //else if (!playerAction.raycastDown.collider.CompareTag("BorderLine"))
        //{
        //    audioSources[Constants.DOWN].Play();
        //    playerAction.raycastDown.collider.GetComponent<AudioSource>().Play();
        //}

        ////Left
        //if (playerAction.raycastLeft.collider == null)
        //{
        //    audioSources[Constants.LEFT].Play();
        //    audioSources[Constants.PATH].Play();
        //}
        //else if (!playerAction.raycastLeft.collider.CompareTag("BorderLine"))
        //{
        //    audioSources[Constants.LEFT].Play();
        //    playerAction.raycastLeft.collider.GetComponent<AudioSource>().Play();
        //}

        ////Right
        //if (playerAction.raycastRight.collider == null)
        //{
        //    audioSources[Constants.RIGHT].Play();
        //    audioSources[Constants.PATH].Play();
        //}
        //else if (!playerAction.raycastRight.collider.CompareTag("BorderLine"))
        //{
        //    audioSources[Constants.RIGHT].Play();
        //    playerAction.raycastRight.collider.GetComponent<AudioSource>().Play();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BorderLine"))
        {
            audioSources[Constants.WALL].Play();
        }
    }

}
