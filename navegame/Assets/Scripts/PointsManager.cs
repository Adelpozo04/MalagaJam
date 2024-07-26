using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{


    #region parameters

    [SerializeField] private float winOverTime = 100;

    [SerializeField] private float timeWhenWin = 1;

    private float totalPoints;

    #endregion

    #region properties

    private float elapsedTime = 0;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(elapsedTime >= timeWhenWin)
        {
            elapsedTime = 0;

            totalPoints += winOverTime;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }

        

    }
}
