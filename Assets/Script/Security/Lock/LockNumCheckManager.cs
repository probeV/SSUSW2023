using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LockNumCheckManager : MonoBehaviour
{
    //public string number1 = "num1";
    //public string number2 = "num2";
    //public string number3 = "num3";

    public int n1, n2, n3;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LockNumCheck()
    {

        GameObject num1Text = GameObject.Find("FirstDigitText");
        GameObject num2Text = GameObject.Find("SecondDigitText");
        GameObject num3Text = GameObject.Find("ThirdDigitText");

        TextMeshProUGUI num1 = num1Text.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI num2 = num2Text.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI num3 = num3Text.GetComponent<TextMeshProUGUI>();

        n1 = int.Parse(num1.text);
        n2 = int.Parse(num2.text);
        n3 = int.Parse(num3.text);

        if (n1 == 1 && n2 == 2 && n3 == 1)
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