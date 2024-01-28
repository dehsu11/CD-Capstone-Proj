using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    private PlayerController playerController;
    public float rotationSpeedFactor = 50f;

    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        transform.Rotate(Vector3.right, playerController.forwardSpeed * rotationSpeedFactor * Time.deltaTime);
    }
}
