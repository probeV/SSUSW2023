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
}

public class AudioNavigation : MonoBehaviour
{
    AudioSource[] audioSources;

    SoundManager soundManager;
    PlayerAction playerAction;

    private void Awake()
    {
        playerAction = GetComponent<PlayerAction>();

        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Start()
    {
        Transform NaviSound = soundManager.transform.Find("NaviSound");

        if (NaviSound != null)
        {
            audioSources = NaviSound.GetComponentsInChildren<AudioSource>();
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("Down " + playerAction.raycastDown.collider);
        Debug.Log("Up " + playerAction.raycastUp.collider);
        Debug.Log("Right " + playerAction.raycastRight.collider);
        Debug.Log("Left " + playerAction.raycastLeft.collider);

        if (soundManager.isNaviSound)
        {
            soundManager.isNaviSound = false;
            NaviSound();
        }


    }

    private void NaviSound()
    {
        //Up
        if (playerAction.raycastUp.collider == null)
        {
            
        }
        else if (!playerAction.raycastUp.collider.CompareTag("BorderLine"))
        {
            audioSources[Constants.UP].Play();
            playerAction.raycastUp.collider.GetComponent<AudioSource>().Play();
        }

        //Down
        if (playerAction.raycastDown.collider == null)
        {

        }
        else if (!playerAction.raycastDown.collider.CompareTag("BorderLine"))
        {
            audioSources[Constants.DOWN].Play();
            playerAction.raycastDown.collider.GetComponent<AudioSource>().Play();
        }

        //Left
        if (playerAction.raycastLeft.collider == null)
        {

        }
        else if (!playerAction.raycastLeft.collider.CompareTag("BorderLine"))
        {
            audioSources[Constants.LEFT].Play();
            playerAction.raycastLeft.collider.GetComponent<AudioSource>().Play();
        }

        //Right
        if (playerAction.raycastRight.collider == null)
        {

        }
        else if (!playerAction.raycastRight.collider.CompareTag("BorderLine"))
        {
            audioSources[Constants.RIGHT].Play();
            playerAction.raycastRight.collider.GetComponent<AudioSource>().Play();
        }
    }

}
