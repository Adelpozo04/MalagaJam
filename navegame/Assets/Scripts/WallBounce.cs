using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{

    #region properties

    private LinealMovement lm_;

    [SerializeField] private bool LeftRight_ = true;

    [SerializeField] private bool UpDown_ = false;

    [SerializeField] private float margenInterno = 0;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        lm_ = GetComponent<LinealMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (LeftRight_)
        {
            if (Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x <= transform.position.x + margenInterno ||
            transform.position.x - margenInterno <= Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x)
            {

                lm_.ChangeDirection(new Vector3(1, 0, 0));

            }
        }

        if(UpDown_)
        {

            if (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0)).y <= transform.position.y + margenInterno ||
            transform.position.y - margenInterno <= Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, 0)).y)
            {

                lm_.ChangeDirection(new Vector3(0, 1, 0));

            }

        }
        

    }
}
