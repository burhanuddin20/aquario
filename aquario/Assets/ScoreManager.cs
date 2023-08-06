using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int gems = 0;
    [SerializeField] private TMPro.TextMeshProUGUI gemScoreText;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            Debug.Log("Food ate updating score");
            gems++;
            gemScoreText.text = gems.ToString();
        }
    }
}
