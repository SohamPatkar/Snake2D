using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SoundType
{
    ButtonClick,
    BackgroundMusic,
    Eaten,
    Death
}

[Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip audioClip;
}


public class SoundManager : MonoBehaviour
{
    [Header("Audios Array")]
    [SerializeField] private Sound[] sounds;
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource, sfxSource;
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayBackgroundMusic(SoundType.BackgroundMusic);
        }
    }

    public void PlayBackgroundMusic(SoundType soundType)
    {
        AudioClip musicClip = GetClip(soundType);
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    private AudioClip GetClip(SoundType soundType)
    {
        Sound sound = Array.Find(sounds, sound => sound.soundType == soundType);
        return sound.audioClip;
    }

    public void PlaySfx(SoundType soundType)
    {
        AudioClip musicClip = GetClip(soundType);
        sfxSource.PlayOneShot(musicClip);
    }
}
