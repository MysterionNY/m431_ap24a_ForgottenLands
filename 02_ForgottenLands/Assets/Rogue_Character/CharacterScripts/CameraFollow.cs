using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // The character to follow
    public float smoothSpeed = 0.125f;  // Smoothness factor
    public Vector3 offset;  // Offset from the character

    // Updates the current player's position and lets the camera follow him
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;  // Calculate the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // Smooth the movement
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);  // Update camera position
    }
}
