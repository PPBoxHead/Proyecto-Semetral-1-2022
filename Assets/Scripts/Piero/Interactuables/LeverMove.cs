using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMove : MonoBehaviour
{
    public bool LeverActivation = false;
    [SerializeField] bool LeverCancel = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && LeverCancel == false)
        {
            LeverActivation = true;
        }
        else if (other.gameObject.tag == "Player" && LeverCancel == true)
        {
            LeverActivation = false;
        }
    }
    private void Update()
    {
        if (LeverActivation == true && Input.GetKeyDown(KeyCode.E))
        {
            LeverCancel = true;
            Invoke("SetBoolTrue", 3f);
        }
    }
    private void SetBoolTrue()
    {
        LeverCancel = false;
    }

    private void OnTriggerExit(Collider other)
    {
        LeverActivation = false;
    }
}
