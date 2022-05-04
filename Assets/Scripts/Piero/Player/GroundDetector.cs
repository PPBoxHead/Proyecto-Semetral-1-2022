using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    [SerializeField] private BoxCollider _gCollider;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            GameManager.GetInstance.GetPlayerController.isGrounded = true;
            Debug.Log("Toco Suelo");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            GameManager.GetInstance.GetPlayerController.isGrounded = false;
            Debug.Log("salio Suelo");
        }
    }







}
