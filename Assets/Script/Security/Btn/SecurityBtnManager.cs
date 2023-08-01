using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SecurityBtnManager : MonoBehaviour
{

    public int n1, n2, n3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnLockCheck()
    {
        GameObject num1Text = GameObject.Find("RedBtnText");
        GameObject num2Text = GameObject.Find("GreenBtnText");
        GameObject num3Text = GameObject.Find("BlueBtnText");

        TextMeshProUGUI num1 = num1Text.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI num2 = num2Text.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI num3 = num3Text.GetComponent<TextMeshProUGUI>();

        n1 = int.Parse(num1.text);
        n2 = int.Parse(num2.text);
        n3 = int.Parse(num3.text);

        if (n1 == 1 && n2 == 0 && n3 == 0)
        {
            Debug.Log("Success");
            AudioManager.instance.PlaySuccess();

        }
        else
        {
            Debug.Log("Fail");
            AudioManager.instance.PlayFail();
        }
    }

}