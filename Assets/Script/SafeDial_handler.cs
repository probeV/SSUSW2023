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
    public Button reset;
    private Quaternion initialRotation;
    public bool success;

    public float rotateSpeed = 0.000001f;
    public float targetAngle1 = 216f; // 목표 회전 각도 (예: 90도)
    public float targetAngle2 = -144f; // 목표 회전 각도 (예: 90도)
    private Vector2 startTouchPos;

    void Start()
    {
        initialRotation = dialobject.transform.rotation;
        success = false;

        // Reset 버튼 클릭 시 ResetRotation() 메서드를 실행하는 이벤트 리스너 등록
        if (reset != null)
        {
            reset.onClick.AddListener(ResetRotation);
        }
    }

    void Update()
    {
        if(dialobject.transform.rotation.z > -0.9001f)
        {
            Debug.Log("hi1");
            if (dialobject.transform.rotation.z < -0.9999f)
            {
                Debug.Log("hi2");
                if (dialobject.transform.rotation.w > 0.2401f)
                {
                    Debug.Log("hi3");
                    if (dialobject.transform.rotation.w < 0.3201f)
                        Debug.Log("ㅎㅇㅎㅇ ");
                }
            }
        }
        Debug.Log("hi");
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

            // 일정 회전 각도에 도달했을 때
            if (Mathf.Abs(rotationZ) >= targetAngle1 || Mathf.Abs(rotationZ) >= targetAngle2)
            {
                Debug.Log("success");
                success = true;
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
        dialobject.transform.rotation = initialRotation;
    }


}
