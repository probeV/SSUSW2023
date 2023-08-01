using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StoryManager : MonoBehaviour
{
    Dictionary<int, StoryData> storyData;
    Dictionary<int, SelectionData> selectData;

    private void Awake()
    {
        storyData = new Dictionary<int, StoryData>();
        selectData  = new Dictionary<int, SelectionData>();

        GenerateData();  
    }

    void GenerateData()
    {
        //Tutorial Start
        storyData.Add(0, new StoryData(1, "....! 눈을 떴을 때는 사방이 암흑이었다. 손목에 있는 시계를 보니 새벽 2시. \n\n내일 있는 전공 시험을 준비하기 위해 새벽까지 과방에서 공부를 하고 있다가 잠들었나보다...."));
        storyData.Add(1, new StoryData(2, "과방 문은 잠겨 있어, 문은 열리지 않는다.\n\n핸드폰은 배터리가 꺼져 있어 연락할 방법이 없다. 밖은 비가 오는지 소리가 폭풍우 소리가 들린다.\n\n내일 아침 9시에 시험있는데..\n\n그 전까지 정보섬을 탈출할 수 있을까?"));
        storyData.Add(2, new StoryData(3, "우선 과방을 나갈 방법을 찾아야 할 것 같다. 과방을 둘러보자."));
        storyData.Add(3, new StoryData(4, "당신이 일어난 책상 위에 올려져 있는 물건들을 찾아보다가 포스트잇을 발견했다. \n\n그러나 어두워서 포스트잇에 적힌 글씨는 잘 보이지 않는다."));
        storyData.Add(4, new StoryData(5, "책상 맞은 편에 있는 냉장고에 가보았다. 냉장고 문을 열자 불빛이 들어 온다. 냉장고 안에서 배터리를 발견했다."));
        storyData.Add(5, new StoryData(6, "냉장고 불빛이 약하긴 하지만, 포스트잇을 불빛에 비춰 볼 수 있다."));
        storyData.Add(6, new StoryData(StoryData.StoryType.Branch, "포스트잇에는 “캐비넷 열쇠를 동방 침대에서 잃어 버렸어요. 찾아주세요. - 동아리원” 이라고 씌여있다."));

        selectData.Add(6, new SelectionData(new int[] { 7, 9 }, new string[] { "침대로 가서 열쇠를 찾아본다", "찾지 않는다" }));

        //Branch 1
        storyData.Add(7, new StoryData(8, "침대에 도착한 당신.\n\n화면을 터치하여 캐비넷 열쇠를 찾아보세요."));
        storyData.Add(8, new StoryData(12, "침대에서 찾은 열쇠로 캐비넷을 열었습니다.\n\n캐비넷 안에서 배터리가 없는 손전등와 금고를 발견했습니다."));

        //Branch 2
        storyData.Add(9, new StoryData(10, "창문 주변을 탐색하다가 쇠 철사를 발견했다."));
        storyData.Add(10, new StoryData(11, "창문에서 찾은 쇠 철사로 캐비넷을 열었습니다.\n\n캐비넷 안에서 배터리가 없는 손전등와 금고를 발견했습니다."));

        //Merge
        storyData.Add(12, new StoryData(13, "원형의 금고를 돌려서 금고를 열어 보세요.\n\n초기화를 원할 시에는 화면 아무곳이나 더블클릭하세요."));

        //Tutorial End
        storyData.Add(13, new StoryData(StoryData.StoryType.End, "금고에서 망치를 발견했다.\n\n문을 부시고 탈출에 성공했다"));

        //Stage 1 Start
        storyData.Add(14, new StoryData(StoryData.StoryType.End, "001 문을 열고 나왔다.\n\n정보섬을 나가야 하는데 소리를 질러 봐도 들리지 않는다.\n\n학교 안에는 사람이 없는 것 같다.\n\n학교 밖의 빗소리는 계속 들린다."));
    }
}
