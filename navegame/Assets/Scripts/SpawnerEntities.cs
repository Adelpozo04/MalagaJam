using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEntities : MonoBehaviour
{

    #region parameters

    [SerializeField] private float spawnTime_;

    #endregion

    #region properties

    [SerializeField] private GameObject [] entityPrefab_;

    private float elapsedTime_;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(elapsedTime_ >= spawnTime_)
        {
            elapsedTime_ = 0;

            int n = Random.Range(0, entityPrefab_.Length);

            Instantiate(entityPrefab_[n], transform.position, Quaternion.identity);
        }
        else
        {
            elapsedTime_ += Time.deltaTime;
        }

    }
}
