using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUnlock : MonoBehaviour
{

    

    [SerializeField] private GameObject [] auxiliarSpawners_;

    [SerializeField] private float unlockTime_;

    private int spawnersUnlocked_ = 0;

    private float elapsedTime_ = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < auxiliarSpawners_.Length; i++)
        {

            auxiliarSpawners_[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {

        

        if (spawnersUnlocked_ < auxiliarSpawners_.Length)
        {

            Debug.Log(elapsedTime_ + " > " + unlockTime_);

            if (elapsedTime_ > unlockTime_)
            {
                elapsedTime_ = 0;

                auxiliarSpawners_[spawnersUnlocked_].SetActive(true);

                spawnersUnlocked_++;
            }
            else
            {
                elapsedTime_ += Time.deltaTime;
            }

        }

    }
}
