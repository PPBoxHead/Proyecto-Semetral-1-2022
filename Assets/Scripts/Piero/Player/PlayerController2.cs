using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PlayerController2 : MonoBehaviour
{
    [Header("Movimiento")]

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Vector3 _currentMovementDir;
    [SerializeField] private float _jumpForce;
    public bool isGrounded;

    [Header("animaciones")]
    [SerializeField] private Animator _animator;






    // Start is called before the first frame update
    void Start()
    {
        //InitializeComponents();
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void InitializeComponents()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    public void Movement()
    {
        //controlamos si corre o camina
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movementSpeed = _runSpeed;
        }
        else
        {
            _movementSpeed = _speed;
        }

        //cargamos la direccion en la que se mueve el jugador
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        _currentMovementDir = new Vector3(0, 0, Horizontal);

        transform.Translate(_currentMovementDir * _movementSpeed * Time.deltaTime);


    }

    public void Jump()
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
    }
   
}
