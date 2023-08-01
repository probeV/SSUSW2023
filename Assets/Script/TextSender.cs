using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextSender : MonoBehaviour
{
    [Header("Dialogs")]
    public int[] storyIds= { 0,1,2,3,4,5,6,7,8,9,10,11,12,13}; // StoryManager에서 가져올 StoryData의 ID들
    public TextMeshProUGUI textObj;
    public static TextSender instance;
    //private int currentStoryId = 0;

    private int currentIndex = 0;

    private void Start()
    {
        instance = this;

        DisplayNextStory();
        
    }

    private void Update()
    {
        
    }

    public void DisplayNextStory()
    {
        Debug.Log("displaynextstory " + currentIndex);
        if (currentIndex < storyIds.Length)
        {
            StoryData story = StoryManager.instance.GetStoryData(storyIds[currentIndex]);
            if (story == null)
            {
                Debug.Log("StoryData with ID " + storyIds[currentIndex] + " not found.");
            }
            else
            {
                Debug.Log("StoryData with ID " + storyIds[currentIndex] + " found.");
                Debug.Log(story.storyData);
                TypingManager.instance.Typing(new string[] { story.storyData }, textObj);
                currentIndex = story.nextStoryId;
            }
        }
    }
}
