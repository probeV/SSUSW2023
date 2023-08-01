using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class StoryData : MonoBehaviour
{
    public enum StoryType { Branch, Puzzle, End };

    public string storyData;
    public int nextStoryId;
    StoryType storyType;

    public StoryData() { }

    public StoryData(int nextStoryId, string storyData)
    {
        this.nextStoryId = nextStoryId;
        this.storyData = storyData;
    }

    public StoryData(StoryType storyType, string storyData)
    {
        this.storyData = storyData;
        this.storyType = storyType;
    }
}
