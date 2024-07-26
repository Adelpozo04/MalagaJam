using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{

    [SerializeField] private float maxLife;
    [SerializeField] private float currentLife; 

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

        if(currentLife < 0)
        {
            Destroy(gameObject);    
        }
    }

}
