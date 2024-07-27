using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource soundFXObject; 
    [SerializeField] private AudioSource soundFXObjectCont;
    [SerializeField] private GameObject motorContObject;


    [SerializeField] private AudioClip[] motorAudio = new AudioClip [3];

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

    public void startMotorsClip(Transform spawnTransform, float volume)
    {
        //Al principio
        //spawn the game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign audio clip 
        audioSource.clip = motorAudio[0];

        //assign volume
        audioSource.volume = volume;

        //play clip
        audioSource.Play();

        //duración del clip
        float clipLenght = audioSource.clip.length;

        Invoke("contAudio", clipLenght);

        //destruye tras sonar
        Destroy(audioSource.gameObject, clipLenght);
    }

    public void endMotorsClip(Transform spawnTransform, float volume)
    {
        if(motorContObject != null)
            Destroy(motorContObject);

        playSFXClip(motorAudio[2], motorContObject.transform, volume);
    }

    private void contAudio(Transform spawnTransform, float volume)
    {

        //spawn the game object
        AudioSource audioSource = Instantiate(soundFXObjectCont, spawnTransform.position, Quaternion.identity);

        //assign audio clip 
        audioSource.clip = motorAudio[0];

        //assign volume
        audioSource.volume = volume;

        //play clip
        audioSource.Play();

        //duración del clip
        float clipLenght2 = audioSource.clip.length;

        motorContObject = audioSource.gameObject;
    }

}
