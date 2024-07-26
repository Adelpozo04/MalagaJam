using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
//    [SerializeField] UnityEvent _onDerrape = new UnityEvent();
//    public UnityEvent OnDerrape => _onDerrape;

    private Rigidbody2D _myRigidBody;

    [SerializeField] private float _maxSpeed;
    public float maxSpeed { get { return _maxSpeed; } set {  _maxSpeed = value; } }

    [SerializeField] private float _force;

    private Vector2 _direction;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void addMaxSpeed(float moreSpeed)
    {
        _maxSpeed += moreSpeed;
    }

    private void Awake()
    {
        //GameManager.Instance.registerPlayerTransform(transform);
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
        if (_myRigidBody.velocity.magnitude < _maxSpeed)
            _myRigidBody.AddForce(_direction * _force, ForceMode2D.Force);
    }
}
