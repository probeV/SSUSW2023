using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class SafeDial_handler : MonoBehaviour, IDragHandler
{
    public GameObject dialobject;
    public GameObject clue_popup;
    public Button reset;
    private Quaternion initialRotation; //초기 회전 각도
    public bool success;
    public bool sound;

    public AudioSource audioSource; // 오디오 소스 컴포넌트

    public float rotateSpeed = 0.000001f;
    public float targetAngle1 = 140f; // 목표 회전 각도 범위1
    public float targetAngle2 = 150f; // 목표 회전 각도 범위2
    private Vector2 startTouchPos;

    void Start()
    {
        initialRotation = dialobject.transform.rotation;
        success = false;
        sound = false;

        // Reset 버튼 클릭 시 ResetRotation() 메서드를 실행하는 이벤트 리스너 등록
        if (reset != null)
        {
            reset.onClick.AddListener(ResetRotation);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 터치가 시작될 때
        if (eventData.delta.sqrMagnitude > 0.1f && eventData.dragging)
        {
            // 터치 위치 계산
            if (startTouchPos == Vector2.zero)
                startTouchPos = eventData.position;

            Vector2 currentTouchPos = eventData.position;
            Vector2 touchDelta = currentTouchPos - startTouchPos;

            // z축 회전 각도 계산
            float rotationZ = Mathf.Atan2(touchDelta.y, touchDelta.x) * Mathf.Rad2Deg;

            // 다이얼 회전
            dialobject.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ * rotateSpeed);
            //Debug.Log(dialobject.transform.rotation + "+" + initialRotation);

            // 일정 회전 각도에 도달했는지 검사
            if (Mathf.Abs(rotationZ) >= targetAngle1)
            {
                Debug.Log("success1");
                success = true;
            } else if (Mathf.Abs(rotationZ) <= targetAngle2)
            {
                Debug.Log("success2");
                success = true;
            }

            //성공 여부 확인 후 소리 실행
            if (success)
            {
                if (!sound)
                {
                    if (audioSource != null)
                    {
                        Debug.Log("sound play");
                        audioSource.Play();
                        sound = true;

                        // 1초 딜레이 후에 OpenPopup() 메서드를 실행합니다.
                        StartCoroutine(DelayedCall());
                        return;
                    }
                }
            }
        }
    }
    

    public void OnEndDrag(PointerEventData eventData)
    {
        startTouchPos = Vector2.zero;
    }

    public void ResetRotation()
    {
        // 초기 회전 값으로 돌아갑니다.
        Debug.Log("reset");
        dialobject.transform.rotation = initialRotation;
        success = false;
        sound = false;
    }

    //OpenPopup()을 위한 딜레이 메서드
    private IEnumerator DelayedCall()
    {
        yield return new WaitForSeconds(1.5f); // 1초 딜레이

        OpenPopup(); // 딜레이 후 실행할 메서드
    }

    private void OpenPopup()
    {
        if (clue_popup != null)
        {
            Debug.Log("clue popup open");
            clue_popup.SetActive(true);
        }
    }
}
