using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCar : MonoBehaviour
{
    
    public float rotationSpeed = 50;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
}
