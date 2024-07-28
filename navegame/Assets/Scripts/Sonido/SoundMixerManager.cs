using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(level)*20f);
    }

    private void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(level) * 20f);
    }

    private void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(level) * 20f);
    }
}
