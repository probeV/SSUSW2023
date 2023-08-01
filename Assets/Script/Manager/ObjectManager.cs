using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    Dictionary<int, ObjectData> objectData;
    Dictionary<int, SelectionData> selectData;

    private void Awake()
    {
        objectData = new Dictionary<int, ObjectData>();
        selectData = new Dictionary<int, SelectionData>();

        GenerateData();
    }


    void GenerateData()
    {


    }

    class Object
    {

    }

    class Door_Lock : Object
    {

    }

    class Object_Locker : Object
    {
        Dictionary<int,  Object_Locker> objectData;
    }

    class Object_Locker_In_Candy : Object_Locker
    {

    }

    class Object_Locker_Empty : Object_Locker
    {

    }

   
}
