using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_bed_key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("key script start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("key check");
        }
    }

    /*void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch key_touch = Input.GetTouch(1);
            Debug.Log(key_touch.position.x);
            Debug.Log(key_touch.position.y);
        }
    }
    private void OnMouseUp() //���콺 ��ư�� �ö� ��
    {
        
    }
    private void OnMouseDrag() //���콺 ��ư�� ���� ���¿��� �̵��� �ϸ� ȣ���.
    {
        
    }*/
}
