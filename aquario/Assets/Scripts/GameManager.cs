using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject foodPrefab;
    public GameObject[] characterPrefabs;
    public Vector2 xRange;
    public Vector2 yRange;
    public GameObject character;

    // Called before start
    private void Awake()
    {
        instance = this;
        LoadCharacter();
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            SpawnFood();
        }
    }

    void LoadCharacter()

    {
        // Manual loading
        // string assetName = "Red";
        // // Load the corresponding asset from the Resources folder
        // GameObject assetPrefab = Resources.Load(assetName) as GameObject;
        // character = Instantiate(assetPrefab);
        
        Vector3 spawn = new Vector3(0, 0, 0);

        int selectedCharacterInt = CharacterSelectionScript.Instance.selectedCharacter;

        GameObject selectedCharacter = CharacterSelectionScript.Instance.characters[selectedCharacterInt];
        character = selectedCharacter;
        character.GetComponent<MovementScript>().cam = Camera.main;
        character.transform.position = spawn;
    }

    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        GameObject _food = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        _food.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.9f, 1f, 0.9f, 1f);
    }
}