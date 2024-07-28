using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{

    [SerializeField] private float maxLife;
    [SerializeField] private float currentLife;
    private float coolDownDeathAnim = 1.0f;
    private bool alive = true;

    [SerializeField] GameObject fuelPrefab;

    [SerializeField] private AudioClip dieClip;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }

    private void Update()
    {
        if (!alive)
        {
            coolDownDeathAnim -= Time.deltaTime;
            if (coolDownDeathAnim <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public bool GetAlive()
    {
        return alive;
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
            GetComponent<Animator>().SetTrigger("Kill");
            int p = GetComponent<ScoreAmound>().GetPoints();
            ScoreManager.Instance.AddScore(p);
            SFXManager.instance.playSFXClip(dieClip, transform, 1f);
            GameObject hwei = Instantiate(fuelPrefab, transform.position, Quaternion.identity);
            //GetComponent<ShotingComponent>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<LinealMovement>().ChangeMove(false);
            alive = false;
        }
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
