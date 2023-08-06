using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    public float currentScale =1f;
    public float scaleSpeed =5f ;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            Debug.Log($"Food ate scaling");
            currentScale *= 1.05f;
            GameManager.instance.SpawnFood();
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1),
            Time.deltaTime * scaleSpeed);
    }
}