using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField]
    private AudioClip currentMusic;
    [SerializeField]
    private AudioSource musicAudioSource;
    [SerializeField]
    private AudioMixerGroup musicGroup;
    [SerializeField]
    private AudioMixerGroup audioGroup;

    [SerializeField]
    Toggle musicToggle;
    [SerializeField]
    Toggle audioToggle;

    public void Awake()
    {
        //musicToggle.isOn = PlayerPrefs.GetInt("_Music") == 1 ? true : false;
        //musicGroup.audioMixer.SetFloat("volumeMusic", PlayerPrefs.GetInt("_Music") == 1 ? 0f : -80f);
        
        //audioToggle.isOn = PlayerPrefs.GetInt("_Audio") == 1 ? true : false;
        //musicGroup.audioMixer.SetFloat("volumeSound", PlayerPrefs.GetInt("_Audio") == 1 ? 0f : -80f);
    }

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip newAudioClip)
    {
        currentMusic = newAudioClip;
        musicAudioSource.loop = true;
        musicAudioSource.clip = newAudioClip;
        musicAudioSource.Play();
    }
    public void PlayMusicOnce(AudioClip newAudioClip)
    {
        currentMusic = newAudioClip;
        musicAudioSource.loop = false;
        musicAudioSource.clip = newAudioClip;
        musicAudioSource.Play();
    }
    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void SwitchMusicState(bool state)
    {
        PlayerPrefs.SetInt("_Music", state ? 1 : 0);
        musicGroup.audioMixer.SetFloat("volumeMusic", state ? 0f : -80f);
    }

    public void SwitchAudioState(bool state)
    {
        PlayerPrefs.SetInt("_Audio", state ? 1 : 0);
        musicGroup.audioMixer.SetFloat("volumeSound", state ? 0f : -80f);
    }


}
