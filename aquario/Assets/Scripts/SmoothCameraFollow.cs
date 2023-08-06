using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour 
{

    public Transform target;
    public float speed;
    public float scaleSpeed;
    public Camera cam;

    private void Start()
    {
        target = GameManager.instance.character.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionLerp = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        positionLerp.z = transform.position.z;
        transform.position = positionLerp;

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5 * target.localScale.x, scaleSpeed * Time.deltaTime);
    }
}
