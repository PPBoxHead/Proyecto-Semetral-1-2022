using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [TextArea(1, 5)]
    [SerializeField] private string Notas;
    
    [Header("Required")]
    [Tooltip("El código necesita ser ajustado a lo que queremos conseguir. El cube en el modelo es para verificar la rotación.")]
    [SerializeField] private Transform _model;

    [Header("Movement")]
    [SerializeField] private float _rotationSpeed = 15;
    [SerializeField] private float _movementSpeed = 10;
    [SerializeField] private float _originalStepOffset;

    [Header("Jump")]
    [SerializeField] private Vector3 _jumpSpeed = Vector3.zero;
    [SerializeField] private float _jumpHeight = 2;
    [Space]
    [Tooltip("Necesitamos ver qué esta causando que esto a veces no se quede verificado o usar otra manera para verificar que está grounded.")]
    [SerializeField] private bool _groundedPlayer;

    [Header("Gravity")]
    [SerializeField] private float _gravityValue = -9.81f;
    [SerializeField] private float _fallGravityValue = -10f;

    private Vector3 _currentMovement;
    //private bool _isJumping = false;

    private CharacterController _controller;
    
    private void Awake() 
    {
        _controller = GetComponent<CharacterController>();
        _originalStepOffset = _controller.stepOffset;
    }

    private void Update() 
    {
        _groundedPlayer = _controller.isGrounded;

        //HandleMovement();
        HandleJump();
        HandleGravity();
    }

    private void FixedUpdate() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        HandleMovement(horizontal);
    }

    private void HandleMovement(float horizontal)
    {
        //float vertical = Input.GetAxisRaw("Vertical");

        //_currentMovement = new Vector3(0, 0, horizontal); //FORMA ORIGINAL DE HACERLO

        _currentMovement.Set(0, 0, horizontal);

        //_currentMovement *= _movementSpeed * Time.deltaTime; //FORMA ORIGINAL DE HACERLO

        _currentMovement = _currentMovement.normalized * _movementSpeed * Time.deltaTime;

        if (_currentMovement != Vector3.zero) {
            //_animator.SetBool("Running", true);

            // Rotate the player
            _model.forward = Vector3.Slerp(_model.forward, _currentMovement, Time.deltaTime * _rotationSpeed);
        }else{
            //_animator.SetBool("Running", false);
        }

        if (_groundedPlayer) _controller.stepOffset = _originalStepOffset;

        _controller.Move(_currentMovement);
        _currentMovement = Vector3.zero;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && _groundedPlayer) {
            PhysicJump(_jumpHeight);
        }

        if (Input.GetButtonUp("Jump") && _jumpSpeed.y > 0) {
            _jumpSpeed.y *= 0.5f;
        }
    }

    private void PhysicJump(float height)
    {
        //_animator.SetBool("Jumping", true);
        _controller.stepOffset = 0;

        _jumpSpeed.y = Mathf.Sqrt(height * -3.0f * _gravityValue); // Optional
    }

    private void HandleGravity()
    {
        _jumpSpeed.y += GetGravity() * Time.deltaTime;
        _controller.Move(_jumpSpeed * Time.deltaTime);

        if (_groundedPlayer && _jumpSpeed.y < 0) {
            _jumpSpeed.y = 0;
            //_animator.SetBool("Jumping", false);
        }
    }

    private float GetGravity()
    {
        float value = _gravityValue;

        if (!_groundedPlayer && _jumpSpeed.y < 0)
            value = _fallGravityValue;

        return value;
    }

}
