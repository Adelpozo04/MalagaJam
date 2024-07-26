using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _myRigidBody;

    //afecta la rapidez del movimiento
    [SerializeField] private float _speedFactor;
    //afecta a la reducci�n de velocidad cuando pierder un motor
    [SerializeField] private float _percentageToReduce;
    //es el factor de reducci�n real que se utiliza leyendo los boleanos
    private float _speed;

    //booleano para cuando pierdes un  motor
    [SerializeField] private bool rightMotorHadDestroyed = false;
    [SerializeField] private bool leftMotorHadDestroyed = false;

    //el comoponente de input para leer la direcci�n
    [SerializeField] private InputTest _myInputTest;

    //direcci�n de movimiento

    private Vector2 _direction;

    public void destroyRightMotor()
    {
        rightMotorHadDestroyed = true;
    }

    public void destroyLeftMotor() { 
        leftMotorHadDestroyed = true; 
    }

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

        //Debug.Log(_direction);

        _speed = _speedFactor;


        if (rightMotorHadDestroyed && !(_direction.y == 1 && !leftMotorHadDestroyed) && _direction.x < 0)
        {
            _speed = _speedFactor - (_speedFactor * _percentageToReduce) / 100;
        }
        else if(leftMotorHadDestroyed && !(_direction.y == 1 && !rightMotorHadDestroyed) && _direction.x > 0)
        {
            _speed = _speedFactor - (_speedFactor * _percentageToReduce) / 100;
        }
        else if(rightMotorHadDestroyed && leftMotorHadDestroyed)
        {
            _speed = _speedFactor - (_speedFactor * _percentageToReduce) / 100;
        }

        _myRigidBody.velocity = _direction * _speed;
        Debug.Log(_speed);
    }
}
