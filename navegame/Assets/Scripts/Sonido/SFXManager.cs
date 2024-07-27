using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource soundFXObject;


    private void Awake()
    {
        if(instance != null)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void playSFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn the game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign audio clip 
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play clip
        audioSource.Play();

        //duración del clip
        float clipLenght = audioSource.clip.length;

        //destruye tras sonar
        Destroy(audioSource.gameObject, clipLenght);

    }

    public void playLongSFXClip()
    {

    }
}
