﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider MusicSlider;
    public static AudioController instancia;
    private const string SFXVolumeKey = "SFXVolume";
    private const string MusicVolumeKey = "MusicVolume";


    [Header("Configura��es de Sons")]
    //public AudioClip bgmSound;
    public AudioClip CoinCollect;
    public AudioClip Audio_Lanterna;
    public AudioClip Audio_Camera;
    public AudioClip Audio_PowerUp;
    public AudioClip Audio_Coletavel;
    public AudioClip Audio_Morte;
    public AudioClip Audio_Pause;
    //public AudioClip Audio_;
    //public AudioClip Audio_;

    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 1.0f);
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1.0f);

        if (SFXSlider != null)
        {
            SFXSlider.value = savedSFXVolume;
        }

        if (MusicSlider != null)
        {
            MusicSlider.value = savedMusicVolume;
        }

        // Configurar os volumes iniciais
        SetMusicSFX();
        SetMusic();
    }

    public void SetMusicSFX()
    {
        if (mixer != null && SFXSlider != null)
        {
            float volume = SFXSlider.value;
            mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
            SFXSlider.value = volume;
            PlayerPrefs.SetFloat(SFXVolumeKey, volume);
            PlayerPrefs.Save();
        }

    }

    public void SetMusic()
    {
        if (mixer != null && MusicSlider != null)
        {
            float volume = MusicSlider.value;
            mixer.SetFloat("Musica", Mathf.Log10(volume) * 20);
            MusicSlider.value = volume;
            PlayerPrefs.SetFloat(MusicVolumeKey, volume);
            PlayerPrefs.Save();
        }

    }
}
