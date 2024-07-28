using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    private void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("Master", level);
    }

    private void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("SFX", level);
    }

    private void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("Music", level);
    }
}
