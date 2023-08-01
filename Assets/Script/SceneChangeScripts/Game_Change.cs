using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Change : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("StoryGameScene_001");
    }
}
