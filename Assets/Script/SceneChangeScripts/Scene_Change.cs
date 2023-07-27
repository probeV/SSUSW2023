using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "StartBtn":
                SceneManager.LoadScene("ThemeSelect");
                break;

            case "MyPageBtn":
                SceneManager.LoadScene("MyPage");
                break;

            case "SettingBtn":
                SceneManager.LoadScene("Settings");
                break;
        }
    }
}
