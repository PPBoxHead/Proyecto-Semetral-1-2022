using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform platform;
    [SerializeField] private Transform[] locations;
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _selfMesh;

    private void Update()
    {
        if(GameManager.GetInstance.GetPlayerController._interacting)
        {
            if(Input.GetKey(KeyCode.A))
            {
                platform.position = Vector3.MoveTowards(platform.transform.position,locations[0].position, moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                platform.position = Vector3.MoveTowards(platform.transform.position, locations[1].position, moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _selfMesh.material = _materials[1];

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.GetInstance.GetPlayerController.Interact();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _selfMesh.material = _materials[0];
        }

            
    }
}
