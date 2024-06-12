using System.Collections;
using UnityEngine;

public class Camera_rotate : MonoBehaviour
{
    public float rotationSpeed = 90.0f; 
    private bool isRotating;
    private bool hasRotated = false; 
    private float rotationTimer = 0.0f; 

    void Update()
    {
        rotationTimer += Time.deltaTime; // this code increments the rotation timer 

        if (rotationTimer >= 2f && !hasRotated) //checks to see if we have reached the 2 second mark yet and that the camera hasn't moved 
        {
            StartCoroutine(RotateCameraCoroutine(Vector3.up, 90.0f, 0.05f)); // rotates 90 degrees (or angle of choice) in 1 second (time of choice)
            hasRotated = true; 
        }
    }
    IEnumerator RotateCameraCoroutine(Vector3 axis, float angle, float duration)
    {
        isRotating = true;

        Quaternion fromRotation = transform.rotation; 
        Quaternion toRotation = transform.rotation * Quaternion.Euler(axis*angle); 

        float elapsed = 0.0f; 
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed/duration); 
            transform.rotation = Quaternion.Slerp(fromRotation, toRotation, t); 
            elapsed += Time.deltaTime; 
            yield return null; 
        }

        transform.rotation = toRotation; // Ends the rotation at our desire angle
        isRotating = false; 
    }
}