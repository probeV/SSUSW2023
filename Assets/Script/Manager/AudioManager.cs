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

    [Header("#SFX")]
    public AudioClip sfxClip;
    public float sfxVolume;
    AudioSource sfxPlayer;

    [Header("#NAVI")]
    public AudioClip[] naviClip;
    public float naviVolume;
    public int naviChannels;
    AudioSource[] naviPlayers;
    int naviChannelIndex=0;

    [Header("#FAIL")]
    public AudioClip failClip;
    public float failVolume;
    AudioSource failPlayer;

    [Header("#SUCCESS")]
    public AudioClip successClip;
    public float successVolume;
    AudioSource successPlayer;

    public enum Navi { Up, Down, Left, Right, PathGuide, WallBlock, B1Guide, F1Guide, F2Guide }

    //bool isWalkAudio = true;

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

        //Sfx
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent= transform;
        sfxPlayer = sfxObject.AddComponent<AudioSource>();
        sfxPlayer.playOnAwake = false;
        sfxPlayer.loop = false;
        sfxPlayer.volume = sfxVolume;
        sfxPlayer.clip = sfxClip;


        GameObject naviObject = new GameObject("NaviPlayer");
        naviObject.transform.parent = transform;
        naviPlayers = new AudioSource[naviChannels];

        for(int index=0; index < naviPlayers.Length; index++)
        {
            naviPlayers[index] = naviObject.AddComponent<AudioSource>();
            naviPlayers[index].playOnAwake = false;
            naviPlayers[index].volume = naviVolume;
        }


        //Fail
        GameObject failObject = new GameObject("failPlayer");
        failObject.transform.parent = transform;
        failPlayer = failObject.AddComponent<AudioSource>();
        failPlayer.playOnAwake = false;
        failPlayer.volume = failVolume;
        failPlayer.clip = failClip;


        //Success
        GameObject successObject = new GameObject("successPlayer");
        successObject.transform.parent = transform;
        successPlayer = successObject.AddComponent<AudioSource>();
        successPlayer.playOnAwake = false;
        successPlayer.volume = successVolume;
        successPlayer.clip = successClip;
        
    }

    public void PlaySfx()
    {
        if(!sfxPlayer.isPlaying)
            sfxPlayer.Play();
    }

    public void StopSfx()
    {
        if(sfxPlayer.isPlaying)
            sfxPlayer.Stop();
    }


    public void TakeNavi(Navi direction, Navi navi)
    {
        if(playNaviCoroutine!= null)
        {
            StopNavi();

            naviChannelIndex = 0;
        }

        naviPlayers[naviChannelIndex++].clip= naviClip[(int)direction];
        naviPlayers[naviChannelIndex++].clip = naviClip[(int)navi];
    }

    public void TakeNaviObject(Navi direction, AudioSource navi)
    {
        if (playNaviCoroutine != null)
        {
            StopNavi();

            naviChannelIndex= 0;
        }

        naviPlayers[naviChannelIndex++].clip = naviClip[(int)direction];
        naviPlayers[naviChannelIndex++].clip = navi.clip;
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

        for (int index = 0; index < naviChannelIndex;)
        {
            yield return new WaitForSeconds(0.1f);
            if (index == 0 || !naviPlayers[index - 1].isPlaying)
            {
                naviPlayers[index].Play();
                index++;
            }
        }
    }

    public void PlayFail()
    {
        failPlayer.Play();
    }

    public void PlaySuccess()
    {
        successPlayer.Play();
    }

    public void PlayInteraction(AudioSource interact)
    {
        interact.Play();
    }
 
}
