using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class My_Page_Change : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadSceneAsync("MyPage");
    }
}
