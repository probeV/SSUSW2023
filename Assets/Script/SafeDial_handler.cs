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
    public float targetAngle1 = 216f; // ��ǥ ȸ�� ���� (��: 90��)
    public float targetAngle2 = -144f; // ��ǥ ȸ�� ���� (��: 90��)
    private Vector2 startTouchPos;

    void Start()
    {
        initialRotation = dialobject.transform.rotation;
        success = false;

        // Reset ��ư Ŭ�� �� ResetRotation() �޼��带 �����ϴ� �̺�Ʈ ������ ���
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
                        Debug.Log("�������� ");
                }
            }
        }
        Debug.Log("hi");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ��ġ�� ���۵� ��
        if (eventData.delta.sqrMagnitude > 0.1f && eventData.dragging)
        {
            // ��ġ ��ġ ���
            if (startTouchPos == Vector2.zero)
                startTouchPos = eventData.position;

            Vector2 currentTouchPos = eventData.position;
            Vector2 touchDelta = currentTouchPos - startTouchPos;

            // z�� ȸ�� ���� ���
            float rotationZ = Mathf.Atan2(touchDelta.y, touchDelta.x) * Mathf.Rad2Deg;

            // ���̾� ȸ��
            dialobject.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ * rotateSpeed);
            //Debug.Log(dialobject.transform.rotation + "+" + initialRotation);

            // ���� ȸ�� ������ �������� ��
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
        // �ʱ� ȸ�� ������ ���ư��ϴ�.
        dialobject.transform.rotation = initialRotation;
    }


}
