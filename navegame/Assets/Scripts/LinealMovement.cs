using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinealMovement : MonoBehaviour
{

    #region parameters

    [SerializeField] private float speed_;

    [SerializeField] private Vector3 dir_;

    #endregion

    #region methods

    public void changeDirection()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += dir_ * speed_ * Time.deltaTime;

    }

    #endregion


}
