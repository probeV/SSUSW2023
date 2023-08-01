using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    PlayerAction playerAction;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#NAVI")]
    public AudioClip[] naviClip;
    public float naviVolume;
    public int channels;
    AudioSource[] naviPlayers;
    int channelIndex=0;

    public enum Navi { Up, Down, Left, Right, PathGuide, WallBlock, B1Guide, F1Guide, F2Guide }

    //Coroutine
    private IEnumerator playNaviCoroutine;

    private void Awake()
    {
        instance= this;
        Init();
    }

    void Init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent= transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        GameObject naviObject = new GameObject("NaviPlayer");
        naviObject.transform.parent = transform;
        naviPlayers = new AudioSource[channels];

        for(int index=0; index < naviPlayers.Length; index++)
        {
            naviPlayers[index] = naviObject.AddComponent<AudioSource>();
            naviPlayers[index].playOnAwake = false;
            naviPlayers[index].volume = naviVolume;
        }
    }

    public void TakeNavi(Navi direction, Navi navi)
    {
        if(playNaviCoroutine!= null)
        {
            StopNavi();

            channelIndex = 0;
        }

        naviPlayers[channelIndex++].clip= naviClip[(int)direction];
        naviPlayers[channelIndex++].clip = naviClip[(int)navi];
    }

    public void TakeNaviObject(Navi direction, AudioSource navi)
    {
        if (playNaviCoroutine != null)
        {
            StopNavi();

            channelIndex= 0;
        }

        naviPlayers[channelIndex++].clip = naviClip[(int)direction];
        naviPlayers[channelIndex++].clip = navi.clip;
    }

    public void PlayNavi()
    {
        playNaviCoroutine=PlayNaviRoutine();

        StartCoroutine(playNaviCoroutine);
    }

    public void StopNavi()
    {
        StopCoroutine(playNaviCoroutine);

        playNaviCoroutine = null;
    }

    IEnumerator PlayNaviRoutine()
    {
        yield return new WaitForSeconds(0.5f);

        for (int index=0 ; index < channelIndex;) 
        {
            yield return new WaitForSeconds(0.1f);
            if (index == 0 || !naviPlayers[index-1].isPlaying)
            {
                naviPlayers[index].Play();
                index++;
            }
        }
    }
}
