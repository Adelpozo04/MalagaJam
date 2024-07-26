using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _myRigidBody;

    [SerializeField] private float _force;
    [SerializeField] private float _reductionForce;

    [SerializeField] private bool rightMotorHadDestroyed;
    [SerializeField] private bool leftMotorHadDestroyed;

    [SerializeField] private InputTest _myInputTest;

    private Vector2 _direction;

    public void SetDirection()
    {
        _direction = _myInputTest.getDir().normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        //_myInputTest = GetComponent<InputTest>();
        _direction = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (_myRigidBody.velocity.magnitude < _maxSpeed)
        SetDirection();
        Debug.Log(_direction);

        //if (rightMotorHadDestroyed && (_direction.y == 1 && !leftMotorHadDestroyed) && _direction.x != 0)
        //{
        //}
        _myRigidBody.velocity = _direction * _force;

    }
}
