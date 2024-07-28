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

    [SerializeField] private bool lateralMovement = false;

    [SerializeField] private bool randomLateralMove = true;

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

        int n = Random.Range(0, 2);

        if (n == 0 && randomLateralMove)
        {
            dir_.x *= -1;
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += dir_ * speed_ * Time.deltaTime;

        if(changeDirSpeed_ != 0)
        {
            if (!lateralMovement)
            {
                dir_.x += changeDirSpeed_;

                if (dir_.x >= maxLateralSpeed_ || dir_.x <= -maxLateralSpeed_)
                {
                    changeDirSpeed_ *= -1;
                }
            }
            else
            {

                dir_.y += changeDirSpeed_;

                if (dir_.y >= maxLateralSpeed_ || dir_.y <= -maxLateralSpeed_)
                {
                    changeDirSpeed_ *= -1;
                }

            }
            
        }

    }

    #endregion


}
