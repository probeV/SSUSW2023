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
    private void OnMouseUp() //마우스 버튼이 올라갈 때
    {
        
    }
    private void OnMouseDrag() //마우스 버튼이 눌린 상태에서 이동을 하면 호출됨.
    {
        
    }*/
}
