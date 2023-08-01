using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecurityBtnScript : MonoBehaviour
{
    public TextMeshProUGUI RedBtnText;
    public TextMeshProUGUI GreenBtnText;
    public TextMeshProUGUI BlueBtnText;

    public string RedBtn, GreenBtn, BlueBtn;

    void Start()
    {
        RedBtnText.text = "0";
        GreenBtnText.text = "0";
        BlueBtnText.text = "0";
    }

    public void Plus1()
    {
        if (RedBtnText.text == "0")
        {
            RedBtnText.text = "1";
        }
        else
            RedBtnText.text = "0";

        RedBtn = RedBtnText.text;
    }

    public void Plus2()
    {
        if (GreenBtnText.text == "0")
        {
            GreenBtnText.text = "1";
        }
        else
            GreenBtnText.text = "0";

        GreenBtn = GreenBtnText.text;
    }

    public void Plus3()
    {
        if (BlueBtnText.text == "0")
        {
            BlueBtnText.text = "1";
        }
        else
            BlueBtnText.text = "0";

        BlueBtn = BlueBtnText.text;
    }
}
