using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class MusicManager : MonoBehaviour
{
    private AudioSource Audio;
    public static MusicManager instance;
    [SerializeField] private AudioMixerGroup Mixer;
    [SerializeField] private string nameKey;
    [SerializeField] private Slider SoundSlider;
    [SerializeField] private bool OnPlayAwake = false;
    [Header("Настройки")]
    [SerializeField] private AudioClip[] audioClip;
    [Range(0f, -100f)]
    [SerializeField] private float MinDB;
    [Range(-100f, 20f)]
    [SerializeField] private float MaxDB;


    public void Start()
    {
        Audio = GetComponent<AudioSource>();
        if (SoundSlider != null)
        {
            SoundSlider.value = PlayerPrefs.GetFloat(nameKey, 1f);
            if (Mathf.Lerp(MinDB, MaxDB, SoundSlider.value) == MinDB)
            {
                Mixer.audioMixer.SetFloat(nameKey, -80f);
            }
            else
            {
                Mixer.audioMixer.SetFloat(nameKey, Mathf.Lerp(MinDB, MaxDB, SoundSlider.value));
            }
        }
        if (OnPlayAwake)
        {
            Mixer.audioMixer.SetFloat(nameKey, MaxDB);
            OnPlayLoop(0);
        }
    }
    // Чтобы запускать музыку один раз
    public void OnPlayOneShot(int number)
    {
        if (!Audio.isPlaying & audioClip.Length != 0 & number <= audioClip.Length - 1)
        {
            Audio.PlayOneShot(audioClip[number]);
        }
    }

    public void OnPlayOneShot(AudioClip audioClip)
    {
        if (!Audio.isPlaying)
        {
            Audio.PlayOneShot(audioClip);
        }
    }
    public void OnPlayLoop(int number)
    {
        if (!Audio.isPlaying & audioClip.Length != 0 & number <= audioClip.Length - 1)
        {
            Audio.loop = true;
            Audio.clip = audioClip[number];
            Audio.Play();
        }
    }
    public void OnPlayOneShotAndEndLast(AudioClip audioClip)
    {
        Audio.Stop();
        Audio.PlayOneShot(audioClip);
    }
    public void OnPlayOneShotAndEndLast(int number)
    {
        Audio.Stop();
        if (audioClip.Length != 0 & number <= audioClip.Length - 1)
        {
            Audio.PlayOneShot(audioClip[number]);
        }
    }
    public void Stop()
    {
        Audio.Stop();
    }

    // Чтобы узнавать ValueSlider
    public float InfoSlider()
    {
        return SoundSlider.value;
    }
    // Для Slider чтобы изменять громкость
    public void AllSoundsChangeVolume()
    {
        if (Mathf.Lerp(MinDB, MaxDB, SoundSlider.value) == MinDB)
        {
            Mixer.audioMixer.SetFloat(nameKey, -80);
            PlayerPrefs.SetFloat(nameKey, MinDB);
        }
        else
        {
            Mixer.audioMixer.SetFloat(nameKey, Mathf.Lerp(MinDB, MaxDB, SoundSlider.value));
            PlayerPrefs.SetFloat(nameKey, SoundSlider.value);
        }
    }
    // Включения звука
    public void OnSound()
    {
        Audio.mute = true;
    }
    // Выключение звука
    public void OffSound()
    {
        Audio.mute = false;
    }
}
