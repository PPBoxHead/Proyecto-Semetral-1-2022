using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePipe : MonoBehaviour
{
    [SerializeField, Range(0, 360)] private float _rotationDegress = 10;
    public Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _rotationDegress = _slider.value;
        transform.eulerAngles = new Vector3(_rotationDegress, 0f ,0f); 
    }


}
