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

    //private int currentStoryId = 0;

    private int currentIndex = 0;

    //public string[] dialogStrings;
    //public TextMeshProUGUI textObj;

    private void Start()
    {
        //TypingManager.instance.Typing(dialogStrings, textObj);
        DisplayNextStory();

        
    }

    public void DisplayNextStory()
    {
        if (currentIndex < storyIds.Length)
        {
            StoryData story = StoryManager.instance.GetStoryData(storyIds[currentIndex]);
            if (story == null)
            {
                Debug.Log("StoryData with ID " + storyIds[currentIndex] + " not found.");
            }
            else
            {
                Debug.Log("story !");
                Debug.Log("StoryData with ID " + storyIds[currentIndex] + " found.");
                TypingManager.instance.Typing(new string[] { story.storyData }, textObj);
                currentIndex = story.nextStoryId;
            }
        }
    }
    /*public void DisplayNextStory()
    {
        StoryData story = StoryManager.instance.GetStoryData(currentStoryId);
        if (story != null)
        {
            TypingManager.instance.Typing(new string[] { story.storyData }, textObj);
            currentStoryId = story.nextStoryId;
        }
    }*/

}
