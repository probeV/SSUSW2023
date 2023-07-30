using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_clue_key_touchpad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDrag() //마우스 버튼이 눌린 상태에서 이동을 하면 호출됨.
    {
        Debug.Log("touch touchpad");
    }
}
