using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Camera cam;
    public float speed = 1f;
    
    // Update is called once per frame
    void Update()
    {

        Vector2 input = Input.mousePosition;
        Vector3 worldInput = cam.ScreenToWorldPoint(input);
        Vector3 newPostion = Vector3.MoveTowards(transform.position, worldInput, speed * Time.deltaTime);
        newPostion.z = transform.position.z;
        transform.position = newPostion;
    }
}
