using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations; //POR AHORA LO DEJO COMENTADO XD

[RequireComponent(typeof(Rigidbody))] //esto añade directamente un rigidbody sin nececidad de añadirlo en editor
public class PlayerController2 : MonoBehaviour
{
    [TextArea(1, 8)]
    [SerializeField] private string Notas;

    [Header("Movimiento")]

    [SerializeField] private float _horizontal;
    [SerializeField] private float _vertical;
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Vector3 _currentMovementDir;
    [SerializeField] private float _jumpForce;
    public bool isGrounded;
    private bool _normalDir = true;
    private Vector3 lastPlaceGround = Vector3.zero;

    [Header("Interactuar")]
    [SerializeField] private bool _interacting = false;


    [SerializeField] private Transform _model;
    [SerializeField] private float _rotationSpeed = 15;
    private Animator _animator;
    private Rigidbody _rb;


    // Start is called before the first frame update
    void Awake()
    {
        InitializeComponents(); //por ahora voy a llamar a esto porque sino el player no salta xd
    }

    // Update is called once per frame
    void Update()
    {

        if(!_interacting)
        {
            Movement();
        }
        


        if(isGrounded)
        {
            lastPlaceGround = transform.position;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void InitializeComponents()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>(); //Como esto estaría solo en el modelo, accedemos a él mediante el hijo
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
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if(_normalDir)
        {
            _currentMovementDir = new Vector3(0, 0, _horizontal);
        }
        else
        {
            _currentMovementDir = new Vector3(-_horizontal, 0,0);
        }

        transform.Translate(_currentMovementDir * _movementSpeed * Time.deltaTime);

        if (_currentMovementDir != Vector3.zero)
        {
            _model.forward = Vector3.Slerp(_model.forward, _currentMovementDir, Time.deltaTime * _rotationSpeed); //rotación del modelo
        }
    }

    public void Jump()
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
    }

    public void ChangeDirection()
    {
        _normalDir = !_normalDir;

    }

    public void MoveToLPG()
    {
        transform.position = lastPlaceGround + new Vector3(0,1,0);
    }

    public void MoveTo(Vector3 newPosition)
    {
        transform.position = new Vector3(newPosition.x, transform.position.y,newPosition.z);
    }

    public void Interact()
    {
        _interacting = !_interacting;
    }

}
