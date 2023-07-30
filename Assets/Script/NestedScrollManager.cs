using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//범위 안에서 수신받음

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;

    const int SIZE = 3;
    float[] pos = new float[SIZE];              //Scrollbar Value 받아오기 
    float distance, curPos, targetPos;
    bool isDrag;                                //드래그 중인가
    int targetIndex;                            //panel의 인덱 


    void Start()
    {
        //거리에 따라 0~1인 pos 대입
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++)
            pos[i] = distance * i;
    }

    float SetPos()
    {
        //절반 거리를 기준으로 가까운 위치를 반
        for (int i = 0; i < SIZE; i++)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        return 0;
    }

    public void OnBeginDrag(PointerEventData eventData) => curPos = SetPos();

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        targetPos = SetPos();

        //절반 거리를 넘지 않아도 마우스를 빠르게 이동하면
        if (curPos == targetPos)
        {
            print(eventData.delta.x);

        //    //스크롤이 왼쪽으로 빠르게 이동 시 목표가 하나 감소
        //    if (eventData.delta.x > 18 && curPos - distance >= 0)
        //    {
        //        --targetIndex;
        //        targetPos = curPos - distance;
        //    }

        //    //스크롤이 오른쪽으로 빠르게 이동 시 목표가 하나 증가
        //    if (eventData.delta.x < -18 && curPos + distance <= 1.01f)
        //    {
        //        ++targetIndex;
        //        targetPos = curPos + distance;
        //    }
        }
    }


    void Update()
    {
        //마우스가 움직이지 않을 때 -> 선형보
        if (!isDrag)
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);

    }
}
