using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{

    #region properties

    private LinealMovement lm_;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        lm_ = GetComponent<LinealMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x <= transform.position.x || 
            transform.position.x <= Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x)
        {

            lm_.ChangeDirection(new Vector3(1, 0, 0));

        }

    }
}
