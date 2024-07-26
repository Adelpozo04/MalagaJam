using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _myRigidBody;

    [SerializeField] private float _force;

    private Vector2 _direction;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _direction = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (_myRigidBody.velocity.magnitude < _maxSpeed)
            _myRigidBody.velocity = _direction * _force ;
    }
}
