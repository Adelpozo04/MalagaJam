using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{

    [SerializeField] private float maxLife;
    [SerializeField] private float currentLife;



    [SerializeField] AudioClip dieClip;

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
            int p = GetComponent<ScoreAmound>().GetPoints();
            ScoreManager.Instance.AddScore(p);
            SFXManager.instance.playSFXClip(dieClip, transform, 1f);
            Destroy(gameObject);    
        }
    }
}
