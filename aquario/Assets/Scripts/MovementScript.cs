using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Camera cam;
    public float speed = 1f;

    public FloatingJoystick joystick;


    // Update is called once per frame
    void Update()
    {
        // Fetching input from the joystick
        Vector3 inputDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f);

        // Calculate new position based on joystick input
        Vector3 newPosition = transform.position + inputDirection * (speed * Time.deltaTime);

        // Maintain the original z position
        newPosition.z = transform.position.z;

        // Set the new position
        transform.position = newPosition;
    }
}