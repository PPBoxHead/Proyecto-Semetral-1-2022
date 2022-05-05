using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public Rigidbody _rigidbody;
    [SerializeField] private bool _isRotated;
    [SerializeField] private bool _isRotating;
    [SerializeField] private float _rotationSpeed;
    void triggerRotation()
    {
        _isRotated = !_isRotated;
        _isRotating = true;
    }
    private void FixedUpdate()
    {
        if(_isRotating == false)
        {
            return;
        }
        int direction = _isRotated ? -1 : 1;
        Quaternion newrotation = Quaternion.Euler(0, 0, _rotationSpeed * Time.fixedDeltaTime * direction);
        _rigidbody.MoveRotation(_rigidbody.rotation * newrotation);
        //Debug.Log(transform.localEulerAngles); pain.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            triggerRotation();
        }
    }
}
