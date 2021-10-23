using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Soundmanager : MonoBehaviour
{
    public AudioSource audioSource;
    public static Soundmanager Instance { get; private set; } = null;
    public AudioSource SESource;
    [SerializeField]
    AudioClip[] audioclip;
    public AudioSource lillia;
    public AudioSource Yonae;


    private void Start()
    {

        if (null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void SetSEVolume(float volume)
    {
        SESource.volume = volume;
    }

}
