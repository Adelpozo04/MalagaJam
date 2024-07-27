using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEntities : MonoBehaviour
{

    #region parameters

    [SerializeField] private float spawnTime_;

    [SerializeField] private int diferenceSpawnRate_;

    #endregion

    #region properties

    [SerializeField] private GameObject [] entityPrefab_;

    [SerializeField] private float[] propEntityAppear_;

    private float elapsedTime_;

    private float addTime_;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        addTime_ = Random.Range(0, diferenceSpawnRate_);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(elapsedTime_ >= (spawnTime_ + addTime_))
        {
            Debug.Log("enemigo sal");

            elapsedTime_ = 0;

            addTime_ = Random.Range(0, diferenceSpawnRate_);

            int prob = Random.Range(0, 101);

            int i = 0;

            bool enemyChoosen = false;

            float totalProb = 0;

            while (i < entityPrefab_.Length && !enemyChoosen)
            {               

                totalProb += propEntityAppear_[i];

                Debug.Log(totalProb + " / " + (prob / 100.0) + " / " + (propEntityAppear_[i]));

                if ((prob / 100.0) > totalProb)
                {
                    i++;
                }
                else
                {
                    enemyChoosen = true;
                }
      
            }

            Debug.Log("Sal enemigo: " + i);

            Instantiate(entityPrefab_[i], transform.position, Quaternion.identity);
        }
        else
        {
            elapsedTime_ += Time.deltaTime;
        }

    }
}
