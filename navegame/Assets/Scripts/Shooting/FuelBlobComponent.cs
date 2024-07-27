using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBlobComponent : MonoBehaviour
{
    #region parameters
    [SerializeField] 
    private float timeAlive = 10f;
    private float elapsedTime = 0;
    #endregion

    #region references
    #endregion

    #region methods
    #endregion


    [SerializeField] private float fuelAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeAlive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            var tumadre = collision.gameObject.GetComponent<ShipManager>();

            if(tumadre != null)
            {
                tumadre.addFuel(fuelAmount);
                Destroy(gameObject);
            }
        }
    }
}
