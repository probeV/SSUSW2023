using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public string objectName;
    public int[] objectId;

    public ObjectData() { }

    public ObjectData(string objectName, int[] objectId)
    {
        this.objectName = objectName;
        this.objectId = objectId;
    }


}
