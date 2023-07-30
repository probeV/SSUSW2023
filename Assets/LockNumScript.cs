using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockNumScript : MonoBehaviour
{
    public TextMeshProUGUI LockNum1Text;
    public TextMeshProUGUI LockNum2Text;
    public TextMeshProUGUI LockNum3Text;

    int number1, number2, number3 = 0;

    void Start()
    {
        LockNum1Text.text = "0";
        LockNum2Text.text = "0";
        LockNum3Text.text = "0";
    }

    public void Plus1()
    {
        number1 = int.Parse(LockNum1Text.text) + 1;
        LockNum1Text.text = number1.ToString();
    }

    public void Plus2()
    {
        number2 = int.Parse(LockNum2Text.text) + 1;
        LockNum2Text.text = number2.ToString();
    }

    public void Plus3()
    {
        number3 = int.Parse(LockNum3Text.text) + 1;
        LockNum3Text.text = number3.ToString();
    }
}
