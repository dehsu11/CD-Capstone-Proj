using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessCarCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.6f);
    }
}