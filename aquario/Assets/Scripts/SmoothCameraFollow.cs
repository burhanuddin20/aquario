using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SmoothCameraFollow : MonoBehaviour 
{
    public Transform target;
    public float speed;
    public float scaleSpeed;
    public Camera cam;
    public Tilemap tilemap;

    // World bounds
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    private void Start()
    {
        Bounds tilemapBounds = tilemap.localBounds; // Now, get the bounds

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        minX = tilemapBounds.min.x + halfWidth;
        maxX = tilemapBounds.max.x - halfWidth;
        minY = tilemapBounds.min.y + halfHeight;
        maxY = tilemapBounds.max.y - halfHeight;
        Debug.Log("Minx" + minX);
    }


    void Update()
    {
        // Move camera towards target
        Vector3 positionLerp = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        positionLerp.z = transform.position.z;

        // Clamp the camera's position to the world bounds
        positionLerp.x = Mathf.Clamp(positionLerp.x, minX, maxX);
        positionLerp.y = Mathf.Clamp(positionLerp.y, minY, maxY);

        transform.position = positionLerp;

        // Adjust the camera's size based on the target's scale
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5 * target.localScale.x, scaleSpeed * Time.deltaTime);
    }

    public void SetTarget(GameObject targetGameObject)
    {
        this.target = targetGameObject.transform;
    }
}