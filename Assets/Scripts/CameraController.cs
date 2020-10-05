using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    private Vector3 velocity;
    private float smoothTime = .5f;

    private void LateUpdate()
    {
        if (Target == null) { return; }
        Vector3 newPosition = Target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Update()
    {
        transform.position = Target.transform.position;
    }
}
