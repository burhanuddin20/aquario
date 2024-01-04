using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Camera cam;
    public float speed = 5f;

    public FloatingJoystick joystick;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public SmoothCameraFollow cameraFollowScript;

    private void Start()
    {
        // cameraFollowScript = cam.GetComponent<SmoothCameraFollow>();
        // minX = cameraFollowScript.minX;
        // maxX = cameraFollowScript.maxX;
        // maxY = cameraFollowScript.maxY;
        // minY = cameraFollowScript.minY;
    }

    // Update is called once per frame
    void Update()
    {
        // Fetching input from the joystick
        Vector3 inputDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f);

        // Calculate new position based on joystick input
        Vector3 newPosition = transform.position + inputDirection * (speed * Time.deltaTime);

        
        // clamp so you cannot go outside world bounds
        //newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        //newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Maintain the original z position
        newPosition.z = transform.position.z;

        // Set the new position
        transform.position = newPosition;
    }
}