using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAmound : MonoBehaviour
{

    [SerializeField] private int pointsWhenKilled = 200;

    
    public int GetPoints()
    {
        return pointsWhenKilled;
    }

}
