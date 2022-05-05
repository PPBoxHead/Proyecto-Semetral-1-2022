using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveMove : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private Transform[] locations;
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _selfMesh;
    

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
