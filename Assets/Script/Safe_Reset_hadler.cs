using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Safe_Reset_hadler : MonoBehaviour
{
    public GameObject dialobject;
    public GameObject resetbutton;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = dialobject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetRotation()
    {
        // �ʱ� ȸ�� ������ ���ư��ϴ�.
        dialobject.transform.rotation = initialRotation;
    }
}
