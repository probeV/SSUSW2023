using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    Dictionary<int, _Object> objectData;

    string[] selectYesOrNo = { "예", "아니오" };

    private void Awake()
    {
        objectData = new Dictionary<int, _Object>();

        GenerateData();
    }

    void GenerateData()
    {
        //Stage 1 B1
        objectData.Add(1000, new _Object("계단으로 1층으로 올라갈까?", selectYesOrNo));
        objectData.Add(1001, new _Object("엘레베이터가 멈췄다!\n\n어떻게 할까?", new string[] {"문을 강제로 열어본다", "비상 호출 벨을 눌러본다"}));
        objectData.Add(1002, new _Object("엘레베이터로 2층으로 올라갈까?", selectYesOrNo));
        objectData.Add(1003, new _Object("비가 와서 나가는 문이 고장났다. 문이 열리지 않는다."));
        objectData.Add(1009, new _Object("빈 사물함이다."));
        objectData.Add(1010, new _Object("사물함 안에는 사탕이 있다. 이거라도 먹어야겠다."));
        objectData.Add(1011, new _Object("빈 사물함이다."));

        //Stage 1 F1
        objectData.Add(1012, new _Object("계단으로 2층으로 올라갈까?", selectYesOrNo));
        objectData.Add(1013, new _Object("계단으로 지하 1층으로 내려갈까?", selectYesOrNo));
        objectData.Add(1014, new _Object("엘레베이터가 작동하지 않는다."));
        objectData.Add(1015, new ObjectExitDoor("문은 열리지 않는다."));
        objectData.Add(1022, new _Object("컴퓨터에서 소리가 나는 것 같다."));
        objectData.Add(1023, new ObjectSecurityOfficeDoor(new string[] { "경비실은 자물쇠로 잠겨있다. 여기를 열어야 할 거 같다." , "경비실이 열렸다!"}));///
        objectData.Add(1025, new _Object("3가지 색 버튼이 있다. 이 버튼으로 문을 열 수 있을 것 같은데..."));
        objectData.Add(1026, new _Object("정수기가 있다. 물을 마실까?", selectYesOrNo));
        objectData.Add(1027, new _Object(""));

        //Stage 1 F2
        objectData.Add(1028, new _Object("계단으로 1층으로 내려갈까?", selectYesOrNo));
        objectData.Add(1029, new _Object("엘레베이터가 작동하지 않는다."));
        objectData.Add(1038, new _Object("잠겨있다."));
        objectData.Add(1040, new _Object(new string[] { "창문 밖으로 진짜 뛰어내릴까?", "창문 밖으로 이불을 내려서 탈출할까?" },  selectYesOrNo));
        objectData.Add(1042, new _Object("잠겨있다."));
        objectData.Add(1045, new _Object("자네 혹..시..."));
        objectData.Add(1046, new _Object(""));
        objectData.Add(1049, new _Object("정수기가 있다. 물을 마실까?", selectYesOrNo));
    }
}
