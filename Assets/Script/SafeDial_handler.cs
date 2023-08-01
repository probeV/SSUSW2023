using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SafeDial_handler : MonoBehaviour
{
    public GameObject dialobject;

    void Start()
    {
    }
    private bool isRotating = false;
    private Vector2 startTouchPos;
    private float startRotation;

    public float rotationSpeed = 5f;

    void Update()
    {
        Debug.Log("update");
        // 터치 입력 처리
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // 터치가 시작될 때
                    startTouchPos = touch.position;
                    startRotation = transform.eulerAngles.z;
                    isRotating = true;
                    break;

                case TouchPhase.Moved:
                    // 터치가 움직일 때
                    if (isRotating)
                    {
                        // 터치 위치 계산
                        Vector2 currentTouchPos = touch.position;
                        Vector2 touchDelta = currentTouchPos - startTouchPos;

                        // z축 회전 각도 계산
                        float rotationZ = startRotation - touchDelta.x * rotationSpeed;

                        // 다이얼 회전
                        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
                        Debug.Log("dial rotation");
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    // 터치가 종료될 때
                    isRotating = false;
                    break;
            }
        }
    }
    public float rotateSpeed = 10;

    /*public void OnDrag(PointerEventData eventData)
    {
        float x = eventData.delta.x * Time.deltaTime * rotateSpeed;
        float y = eventData.delta.y * Time.deltaTime * rotateSpeed;
        

        transform.Rotate(0, 0, -x);
        transform.Rotate(0, 0, y);

        transform.rotation = Quaternion.Euler(0, 0, 10);
        Debug.Log("드래그");
    }*/
}
