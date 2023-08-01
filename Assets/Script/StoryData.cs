using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class StoryData
{
    public enum StoryType { Null, Branch, Puzzle, End };

    public string storyData;
    public int nextStoryId;
    StoryType storyType;

    public StoryData() { }

    public StoryData(int nextStoryId, string storyData)
    {
        this.nextStoryId = nextStoryId;
        this.storyData = storyData;
        this.storyType = StoryType.Null;
    }

    public StoryData(StoryType storyType, string storyData)
    {
        this.storyData = storyData;
        this.storyType = storyType;
    }

    public StoryType GetStoryType(StoryData story)
    {
        return storyType;
    }
}
