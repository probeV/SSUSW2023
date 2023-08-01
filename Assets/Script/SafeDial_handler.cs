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
    private Quaternion initialRotation; //�ʱ� ȸ�� ����
    public bool success;
    public bool sound;

    public AudioSource audioSource; // ����� �ҽ� ������Ʈ

    public float rotateSpeed = 0.000001f;
    public float targetAngle1 = 140f; // ��ǥ ȸ�� ���� ����1
    public float targetAngle2 = 150f; // ��ǥ ȸ�� ���� ����2
    private Vector2 startTouchPos;

    void Start()
    {
        initialRotation = dialobject.transform.rotation;
        success = false;
        sound = false;

        // Reset ��ư Ŭ�� �� ResetRotation() �޼��带 �����ϴ� �̺�Ʈ ������ ���
        if (reset != null)
        {
            reset.onClick.AddListener(ResetRotation);
        }
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

            // ���� ȸ�� ������ �����ߴ��� �˻�
            if (Mathf.Abs(rotationZ) >= targetAngle1)
            {
                Debug.Log("success1");
                success = true;
            } else if (Mathf.Abs(rotationZ) <= targetAngle2)
            {
                Debug.Log("success2");
                success = true;
            }

            //���� ���� Ȯ�� �� �Ҹ� ����
            if (success)
            {
                if (!sound)
                {
                    if (audioSource != null)
                    {
                        Debug.Log("sound play");
                        audioSource.Play();
                        sound = true;

                        // 1�� ������ �Ŀ� OpenPopup() �޼��带 �����մϴ�.
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
        // �ʱ� ȸ�� ������ ���ư��ϴ�.
        Debug.Log("reset");
        dialobject.transform.rotation = initialRotation;
        success = false;
        sound = false;
    }

    //OpenPopup()�� ���� ������ �޼���
    private IEnumerator DelayedCall()
    {
        yield return new WaitForSeconds(1.5f); // 1�� ������

        OpenPopup(); // ������ �� ������ �޼���
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
