using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    //TODO: Testear los cambios
    private Rigidbody2D _myRigidBody;

    private Transform myTr;
    
    //afecta la rapidez del movimiento
    [SerializeField] private float _speedFactor;
    //afecta a la reducci�n de velocidad cuando pierder un motor
    [SerializeField] private float _percentageToReduce;
    //La velocidad real al moverse hacia la izquierda
    private float _leftSpeed;
    //La velocidad real al moverse hacia la derecha
    private float _rightSpeed;

    //el comoponente de input para leer la direcci�n
    [SerializeField] private InputTest _myInputTest;

    //direcci�n de movimiento
    private Vector2 _direction;

    [SerializeField] AudioClip _destroyMotorClip;

    public void destroyRightMotor()
    {
        _rightSpeed = _speedFactor - (_speedFactor * _percentageToReduce) / 100;
        SFXManager.instance.playSFXClip(_destroyMotorClip, transform, 1f);
    }    

    public void destroyLeftMotor() { 
        _leftSpeed = _speedFactor - (_speedFactor * _percentageToReduce) / 100;
        SFXManager.instance.playSFXClip(_destroyMotorClip, transform, 1f);
    }

    public void SetDirection()
    {
        _direction = _myInputTest.getDir().normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _direction = Vector2.zero;
        _rightSpeed = _speedFactor;
        _leftSpeed = _speedFactor;
        myTr = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (_myRigidBody.velocity.magnitude < _maxSpeed)
        SetDirection();

        //Debug.Log(_direction);
        
        if (_direction.x <= 0 && myTr.position.x > 20)
        {
            _myRigidBody.velocity = _direction * _rightSpeed;
        }
        else if (myTr.position.x < 200)
        {
            _myRigidBody.velocity = _direction * _leftSpeed;
        }
        if (_direction.y != 0)
        {
            //Para que si se va hacia alante o hacia atrás, la vecidad sea la media de las velocidades laterales
            _myRigidBody.velocity = _direction * (_leftSpeed + _rightSpeed) / 2;
        }

        //Debug.Log(_myRigidBody.velocity.x);
    }
}
