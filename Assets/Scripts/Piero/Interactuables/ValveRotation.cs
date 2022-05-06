using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveRotation : MonoBehaviour
{

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform platform;
    [SerializeField] private float _maxRot, _minRot;
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _selfMesh;
    [SerializeField] private float _detectDistance;

    private void Update()
    {
        if (GameManager.GetInstance.GetPlayerController._interacting)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (platform.rotation.x >= _minRot)
                {
                    platform.eulerAngles += new Vector3(-_rotateSpeed * Time.deltaTime, 0f, 0f);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if(platform.rotation.x <= _maxRot)
                {
                    Debug.Log("rota d");
                    platform.eulerAngles -= new Vector3(-_rotateSpeed * Time.deltaTime , 0f, 0f);
                }
                
            }
        }

        if (Vector3.Distance(transform.position, GameManager.GetInstance.GetPlayerController.ptransform) < _detectDistance)
        {
            _selfMesh.material = _materials[1];

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.GetInstance.GetPlayerController.Interact();
            }
        }
        else
        {
            _selfMesh.material = _materials[0];
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, _detectDistance);
    }
}
