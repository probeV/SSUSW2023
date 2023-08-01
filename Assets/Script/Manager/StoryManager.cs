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
        storyData.Add(0, new StoryData(1, "....! ���� ���� ���� ����� �����̾���. �ո� �ִ� �ð踦 ���� ���� 2��. \n\n���� �ִ� ���� ������ �غ��ϱ� ���� �������� ���濡�� ���θ� �ϰ� �ִٰ� ����������...."));
        storyData.Add(1, new StoryData(2, "���� ���� ��� �־�, ���� ������ �ʴ´�.\n\n�ڵ����� ���͸��� ���� �־� ������ ����� ����. ���� �� ������ �Ҹ��� ��ǳ�� �Ҹ��� �鸰��.\n\n���� ��ħ 9�ÿ� �����ִµ�..\n\n�� ������ �������� Ż���� �� ������?"));
        storyData.Add(2, new StoryData(3, "�켱 ������ ���� ����� ã�ƾ� �� �� ����. ������ �ѷ�����."));
        storyData.Add(3, new StoryData(4, "����� �Ͼ å�� ���� �÷��� �ִ� ���ǵ��� ã�ƺ��ٰ� ����Ʈ���� �߰��ߴ�. \n\n�׷��� ��ο��� ����Ʈ�տ� ���� �۾��� �� ������ �ʴ´�."));
        storyData.Add(4, new StoryData(5, "å�� ���� �� �ִ� ����� �����Ҵ�. ����� ���� ���� �Һ��� ��� �´�. ����� �ȿ��� ���͸��� �߰��ߴ�."));
        storyData.Add(5, new StoryData(6, "����� �Һ��� ���ϱ� ������, ����Ʈ���� �Һ��� ���� �� �� �ִ�."));
        storyData.Add(6, new StoryData(StoryData.StoryType.Branch, "����Ʈ�տ��� ��ĳ��� ���踦 ���� ħ�뿡�� �Ҿ� ���Ⱦ��. ã���ּ���. - ���Ƹ����� �̶�� �����ִ�."));

        selectData.Add(6, new SelectionData(new int[] { 7, 9 }, new string[] { "ħ��� ���� ���踦 ã�ƺ���", "ã�� �ʴ´�" }));

        //Branch 1
        storyData.Add(7, new StoryData(8, "ħ�뿡 ������ ���.\n\nȭ���� ��ġ�Ͽ� ĳ��� ���踦 ã�ƺ�����."));
        storyData.Add(8, new StoryData(12, "ħ�뿡�� ã�� ����� ĳ����� �������ϴ�.\n\nĳ��� �ȿ��� ���͸��� ���� ������� �ݰ� �߰��߽��ϴ�."));

        //Branch 2
        storyData.Add(9, new StoryData(10, "â�� �ֺ��� Ž���ϴٰ� �� ö�縦 �߰��ߴ�."));
        storyData.Add(10, new StoryData(11, "â������ ã�� �� ö��� ĳ����� �������ϴ�.\n\nĳ��� �ȿ��� ���͸��� ���� ������� �ݰ� �߰��߽��ϴ�."));

        //Merge
        storyData.Add(12, new StoryData(13, "������ �ݰ� ������ �ݰ� ���� ������.\n\n�ʱ�ȭ�� ���� �ÿ��� ȭ�� �ƹ����̳� ����Ŭ���ϼ���."));

        //Tutorial End
        storyData.Add(13, new StoryData(StoryData.StoryType.End, "�ݰ��� ��ġ�� �߰��ߴ�.\n\n���� �νð� Ż�⿡ �����ߴ�"));

        //Stage 1 Start
        storyData.Add(14, new StoryData(StoryData.StoryType.End, "001 ���� ���� ���Դ�.\n\n�������� ������ �ϴµ� �Ҹ��� ���� ���� �鸮�� �ʴ´�.\n\n�б� �ȿ��� ����� ���� �� ����.\n\n�б� ���� ���Ҹ��� ��� �鸰��."));
    }
}
