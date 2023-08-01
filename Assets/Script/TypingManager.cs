using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class TypingManager : MonoBehaviour
{
    public static TypingManager instance;

    //기본 속도 : 0.08
    [Header("Times for each character")]
    public float timeForCharacter;


    //빠른 속도 버전 : 0.03
    [Header("Times for each character when speed up")]
    public float timeForCharacter_Fast;
    
    float characterTime;                //실제 적용되는 문자열 속도

    string[] dialogsSave;                //임시 저장되는 대화 오브젝트와 대화 내용
    TextMeshProUGUI tmpSave;

    public static bool isDialogEnd;
   
    bool isTypingEnd = false;           //타이핑이 끝났는가
    int dialogNumber = 0;               //대화 문단 숫자
   
    float timer;                        //내부 시간 타이머


    //Awake Method
    private void Awake()
    {
        //싱글톤 패턴 구현
        instance = this;
        

        timer = timeForCharacter;
        characterTime = timeForCharacter;           //실제 적용되는 타자시
    }


    public void Typing(string[] dialogs, TextMeshProUGUI textObj)
    {
        Debug.Log("Typing");
        isDialogEnd = false;
        dialogsSave = dialogs;
        tmpSave = textObj;

        char[] chars = dialogs[dialogNumber].ToCharArray();
        StartCoroutine(Typer(chars, textObj)); 

    }

    public void GetInputDown()
    {
        if (dialogsSave != null)
        {
            if (isTypingEnd)
            {
                tmpSave.text = ""; //비어있는 문장 넘겨서 초기화. 
                isDialogEnd = true; 
                dialogsSave = null;
                tmpSave = null;
                dialogNumber = 0;
                TextSender.instance.DisplayNextStory();

            }
            else
            {
                characterTime = timeForCharacter_Fast; //빠른 문장 넘김.
            }
        }
    }

    public void GetInputUp()
    {
        //인풋이 끝났을때.
        if (dialogsSave != null)
        {
            characterTime = timeForCharacter;            
        }
    }

    IEnumerator Typer(char[] chars, TextMeshProUGUI textObj)
    {
        Debug.Log("typer");
        int currentChar = 0;
        int charLength = chars.Length;
        isTypingEnd = false;

        while (currentChar < charLength)
        {
            if (timer >= 0)
            {
                yield return null;
                timer -= Time.deltaTime;
            }
            else
            {
                textObj.text += chars[currentChar].ToString();
                currentChar++;
                timer = characterTime; //타이머 초기화
            }
        }
        if (currentChar >= charLength)
        {
            isTypingEnd = true;

            dialogNumber++;
            yield break;
        }
    }
}

