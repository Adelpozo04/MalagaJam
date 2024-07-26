using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] UnityEvent _onDerrape = new UnityEvent();
    public UnityEvent OnDerrape => _onDerrape;

    private Rigidbody2D _myRigidBody;

    [SerializeField] private float _maxSpeed;
    public float maxSpeed { get { return _maxSpeed; } set {  _maxSpeed = value; } }

    [SerializeField] private float _force;

    private Vector2 _direction;

    private bool _borracho;

    private bool _derrape;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mancha")
        {
            _borracho = true;
        }
        if(collision.gameObject.tag == "cigarro")
        {
            GetComponent<TobaccoNerf>().nerf();
            collision.transform.parent.GetComponent<CreateFume>().Fumar();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mancha")
        {
            _borracho = false;
        }
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        _direction *= _borracho ? -1 : 1;
    }

    public void SetDerrape(bool derrape)
    {
        _derrape = derrape;
    }
    public void addMaxSpeed(float moreSpeed)
    {
        _maxSpeed += moreSpeed;
    }

    private void Awake()
    {
        GameManager.Instance.registerPlayerTransform(transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _direction = Vector2.zero;
        _borracho = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_myRigidBody.velocity.magnitude < _maxSpeed)
            _myRigidBody.AddForce(_direction * _force, ForceMode2D.Force);

        SetDerrape(_derrape);

        if (_derrape && _myRigidBody.velocity.magnitude < _maxSpeed)
        {
            _onDerrape.Invoke();
            if(_myRigidBody.velocity.magnitude > 0 && _myRigidBody.velocity.x > 0)
            {
                _myRigidBody.AddForce(new Vector2(0, 1)*Time.deltaTime, ForceMode2D.Force);
            }
            else if(_myRigidBody.velocity.magnitude > 0 && _myRigidBody.velocity.x < 0)
            {
                _myRigidBody.AddForce(new Vector2(0, -1)*Time.deltaTime, ForceMode2D.Force);
            }
        }

    }
}
