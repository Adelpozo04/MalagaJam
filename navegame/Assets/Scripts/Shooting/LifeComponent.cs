using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{

    [SerializeField] private float maxLife;
    [SerializeField] private float currentLife;

    [SerializeField] private bool isPlayer;

    [SerializeField] private LeaderBoard leaderBoard_;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"> must be positive</param>
    public void reciveDamage(float damage)
    {
        currentLife -= damage;

        if(currentLife <= 0)
        {

            if (isPlayer)
            {
                leaderBoard_.SumbitScoreRoutine(ScoreManager.Instance.GetScore());
            }
            else
            {
                int p = GetComponent<ScoreAmound>().GetPoints();

                ScoreManager.Instance.AddScore(p);
            }

            Destroy(gameObject);    
        }
    }

    public bool getIsPlayer() { return isPlayer; }
}
