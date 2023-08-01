using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    Dictionary<int, _Object> objectData;

    string[] selectYesOrNo = { "��", "�ƴϿ�" };

    private void Awake()
    {
        objectData = new Dictionary<int, _Object>();

        GenerateData();
    }

    void GenerateData()
    {
        //Stage 1 B1
        objectData.Add(1000, new _Object("������� 1������ �ö󰥱�?", selectYesOrNo));
        objectData.Add(1001, new _Object("���������Ͱ� �����!\n\n��� �ұ�?", new string[] {"���� ������ �����", "��� ȣ�� ���� ��������"}));
        objectData.Add(1002, new _Object("���������ͷ� 2������ �ö󰥱�?", selectYesOrNo));
        objectData.Add(1003, new _Object("�� �ͼ� ������ ���� ���峵��. ���� ������ �ʴ´�."));
        objectData.Add(1009, new _Object("�� �繰���̴�."));
        objectData.Add(1010, new _Object("�繰�� �ȿ��� ������ �ִ�. �̰Ŷ� �Ծ�߰ڴ�."));
        objectData.Add(1011, new _Object("�� �繰���̴�."));

        //Stage 1 F1
        objectData.Add(1012, new _Object("������� 2������ �ö󰥱�?", selectYesOrNo));
        objectData.Add(1013, new _Object("������� ���� 1������ ��������?", selectYesOrNo));
        objectData.Add(1014, new _Object("���������Ͱ� �۵����� �ʴ´�."));
        objectData.Add(1015, new ObjectExitDoor("���� ������ �ʴ´�."));
        objectData.Add(1022, new _Object("��ǻ�Ϳ��� �Ҹ��� ���� �� ����."));
        objectData.Add(1023, new ObjectSecurityOfficeDoor(new string[] { "������ �ڹ���� ����ִ�. ���⸦ ����� �� �� ����." , "������ ���ȴ�!"}));///
        objectData.Add(1025, new _Object("3���� �� ��ư�� �ִ�. �� ��ư���� ���� �� �� ���� �� ������..."));
        objectData.Add(1026, new _Object("�����Ⱑ �ִ�. ���� ���Ǳ�?", selectYesOrNo));
        objectData.Add(1027, new _Object(""));

        //Stage 1 F2
        objectData.Add(1028, new _Object("������� 1������ ��������?", selectYesOrNo));
        objectData.Add(1029, new _Object("���������Ͱ� �۵����� �ʴ´�."));
        objectData.Add(1038, new _Object("����ִ�."));
        objectData.Add(1040, new _Object(new string[] { "â�� ������ ��¥ �پ����?", "â�� ������ �̺��� ������ Ż���ұ�?" },  selectYesOrNo));
        objectData.Add(1042, new _Object("����ִ�."));
        objectData.Add(1045, new _Object("�ڳ� Ȥ..��..."));
        objectData.Add(1046, new _Object(""));
        objectData.Add(1049, new _Object("�����Ⱑ �ִ�. ���� ���Ǳ�?", selectYesOrNo));
    }
}
