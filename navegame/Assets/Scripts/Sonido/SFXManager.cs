using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] private AudioSource soundFXObjectCont;
    [SerializeField] private AudioSource MusicObjectCont;

    [SerializeField] private GameObject motorStartObject;
    [SerializeField] private GameObject motorContObject;

    [SerializeField] private Transform playerTransform;


    [SerializeField] private AudioClip[] motorAudio = new AudioClip[3];

    private bool rightSpeakerAlive = true;
    private bool leftSpeakerAlive = true;
    private float volumeFactor = 1;



    private float elapsedTime;

    private float changeTime;
    [SerializeField] private float minChangeTime;
    [SerializeField] private float maxChangeTime;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
         
        if(!leftSpeakerAlive && !rightSpeakerAlive)
        {
            elapsedTime += Time.deltaTime;


            if (elapsedTime > changeTime)
            {

                print("aquuuuuuuuuuuuuuuuuuiiiiiiiiiiiiiiiiiiii");
                var lado = Random.Range((int)1, (int)3);

                setPanStereo(lado == 1 ? 1 : -1);


                elapsedTime = 0;
                changeTime = Random.Range(minChangeTime, maxChangeTime);

            }
        }
    }
    public void playSFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn the game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign audio clip 
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = soundFXObject.volume;

        //play clip
        audioSource.Play();

        //duración del clip
        float clipLenght = audioSource.clip.length;

        //destruye tras sonar
        Destroy(audioSource.gameObject, clipLenght);

    }

    public void startMotorsClip()
    {
        if (motorContObject != null || motorStartObject != null)
            return;

        //Al principio
        //spawn the game object
        AudioSource audioSource = Instantiate(soundFXObject, playerTransform.position, Quaternion.identity);

        //assign audio clip 
        audioSource.clip = motorAudio[0];

        //assign volume
        audioSource.volume = soundFXObject.volume;

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
        audioSource.volume = soundFXObjectCont.volume;

        //play clip
        audioSource.Play();

        //duración del clip
        //float clipLenght1= audioSource.clip.length;

        motorContObject = audioSource.gameObject;
    }

    private void setPanStereo(float value)
    {
        soundFXObject.panStereo = value;
        soundFXObjectCont.panStereo = value;
        MusicObjectCont.panStereo = value;
    }

    private void mute()
    {
        soundFXObject.volume = 0;
        soundFXObjectCont.volume = 0;
        MusicObjectCont.volume = 0;
    }

    private bool allAlive()
    {
        return leftSpeakerAlive || rightSpeakerAlive;
    }

    /// <summary>
    /// Destruyes el izquierdo con un false y el derecho con un true
    /// </summary>
    public void destroySpeaker(bool derecho = true)
    {
        if (!derecho && allAlive())
        {
            leftSpeakerAlive = false;
            setPanStereo(1f);
        }
        else if (derecho && allAlive())
        {
            rightSpeakerAlive = false;
            setPanStereo(-1f);
        }
        else
        {
            changeTime = Random.Range(minChangeTime, maxChangeTime);
            elapsedTime = 0;    

        }
            //mute();
    }
   
    public void ResetAudio()
    {

        soundFXObject.panStereo = 0;
        soundFXObjectCont.panStereo = 0;
        soundFXObject.volume = 1;
        soundFXObjectCont.volume = 1;
    }
    private void Start()
    {
        ResetAudio();
    }
}
