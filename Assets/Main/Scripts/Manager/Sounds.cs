using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Clip
{
    public string Name;
    public AudioClip clip;
}

public class Sound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioSource audioSE;
    public List<Clip> clips = new List<Clip>();
    public static Sound Instance { get; private set; } = null;
    private void Awake()
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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeClip(string name, bool loop)
    {
        Clip find = clips.Find((o) => { return o.Name == name; });
        if (find != null)
        {
            if (loop == true)
            {
                audioSource.Stop();
                audioSource.clip = find.clip;
                audioSource.loop = false;
                audioSource.Play();
            }
            else if (loop == false)
            {
                audioSE.clip = find.clip;
                audioSE.loop = false;
                audioSE.Play();

            }
        }
    }
}
