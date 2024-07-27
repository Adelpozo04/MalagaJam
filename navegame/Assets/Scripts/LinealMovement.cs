using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinealMovement : MonoBehaviour
{

    #region parameters

    [SerializeField] private float speed_ = 2;

    [SerializeField] private Vector3 dir_ = new Vector3(0,-1,0);

    [SerializeField] private float changeDirSpeed_ = 0;

    [SerializeField] private float maxLateralSpeed_ = 1;

    #endregion

    #region methods

    public void ChangeDirection(Vector3 dir)
    {

        if(dir.x > 0)
        {
            dir_.x *= -1;
        }

        if(dir.y > 0)
        {
            dir_.y *= -1;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += dir_ * speed_ * Time.deltaTime;

        if(changeDirSpeed_ != 0)
        {
            dir_.x += changeDirSpeed_; 

            if(dir_.x >= maxLateralSpeed_ || dir_.x <= -maxLateralSpeed_)
            {
                changeDirSpeed_ *= -1;
            }
        }

    }

    #endregion


}