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
        // ��ġ �Է� ó��
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // ��ġ�� ���۵� ��
                    startTouchPos = touch.position;
                    startRotation = transform.eulerAngles.z;
                    isRotating = true;
                    break;

                case TouchPhase.Moved:
                    // ��ġ�� ������ ��
                    if (isRotating)
                    {
                        // ��ġ ��ġ ���
                        Vector2 currentTouchPos = touch.position;
                        Vector2 touchDelta = currentTouchPos - startTouchPos;

                        // z�� ȸ�� ���� ���
                        float rotationZ = startRotation - touchDelta.x * rotationSpeed;

                        // ���̾� ȸ��
                        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
                        Debug.Log("dial rotation");
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    // ��ġ�� ����� ��
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
        Debug.Log("�巡��");
    }*/
}
