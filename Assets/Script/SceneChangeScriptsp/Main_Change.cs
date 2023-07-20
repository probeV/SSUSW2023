using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Change : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadSceneAsync("StartMenuScene");
    }
}
