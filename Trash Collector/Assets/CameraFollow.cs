using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow (the truck)
    public Vector3 offset = new Vector3(0, 5, -10); // Default offset to position the camera

    public float followSpeed = 2f; // Speed at which the camera follows the target

    void LateUpdate()
    {
        // Smoothly move the camera to follow the target
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
