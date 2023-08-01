using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionData : MonoBehaviour
{
    string []selectData;
    int []nextStoryId;

    public SelectionData() { }

    public SelectionData(int[] nextStoryId, string [] selectData)
    {
        this.nextStoryId = nextStoryId;
        this.selectData = selectData;
    }

}
