using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource soundFXObject; 
    [SerializeField] private AudioSource soundFXObjectCont;

    [SerializeField] private GameObject motorStartObject;
    [SerializeField] private GameObject motorContObject;

    [SerializeField] private Transform playerTransform;


    [SerializeField] private AudioClip[] motorAudio = new AudioClip [3];

    private void Awake()
    {
        if(instance != null)
            Destroy(this);
        else
            instance = this;
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

    public void startMotorsClip()
    {
        if(motorContObject != null || motorStartObject != null)
            return;

        //Al principio
        //spawn the game object
        AudioSource audioSource = Instantiate(soundFXObject, playerTransform.position, Quaternion.identity);

        //assign audio clip 
        audioSource.clip = motorAudio[0];

        //assign volume
        audioSource.volume = 1f;

        //play clip
        audioSource.Play();

        //duración del clip
        float clipLenght = audioSource.clip.length;

        Invoke("contAudio", clipLenght);
        motorStartObject = audioSource.gameObject;
    }

    public void endMotorsClip()
    {

        if (motorStartObject != null)
        {
            Destroy(motorStartObject);
            motorStartObject = null;
        }

        if (motorContObject != null)
        {
            Destroy(motorContObject);
            motorContObject = null;
        }

        playSFXClip(motorAudio[2], playerTransform.transform, 1f);
    }

    private void contAudio()
    {


        if (motorStartObject == null)
            return;

        if (motorStartObject != null)
        {
            Destroy(motorStartObject);
            motorStartObject = null;
        }

        if (motorContObject != null)
        {
            Destroy(motorContObject);
            motorContObject = null;
        }

        //spawn the game object
        AudioSource audioSource = Instantiate(soundFXObjectCont, playerTransform.position, Quaternion.identity);

        //assign audio clip 
        audioSource.clip = motorAudio[1];

        //assign volume
        audioSource.volume = 0.5f;

        //play clip
        audioSource.Play();

        //duración del clip
        //float clipLenght1= audioSource.clip.length;

        motorContObject = audioSource.gameObject;
    }

}
