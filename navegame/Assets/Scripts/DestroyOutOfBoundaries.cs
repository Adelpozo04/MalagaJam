using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundaries : MonoBehaviour
{

    #region parameters

    [SerializeField] private bool outOfFloor = true;

    [SerializeField] private bool outOfRight = false;

    [SerializeField] private bool outOfLeft = false;

    [SerializeField] private float margen = 8;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (outOfFloor)
        {
            if (Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, 0)).y >= transform.position.y + margen)
            {

                Destroy(gameObject);

            }
        }
        else
        {

            if (Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y <= transform.position.y - margen)
            {

                Destroy(gameObject);

            }

        }

        if (outOfLeft)
        {
            if (Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, 0)).x >= transform.position.x + margen)
            {

                Destroy(gameObject);

            }
        }

        if (outOfRight)
        {

            if (Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x <= transform.position.x - margen)
            {

                Destroy(gameObject);

            }

        }
        
    }
}
