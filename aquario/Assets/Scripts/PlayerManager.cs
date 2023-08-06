using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //character
    public GameObject[] characterPrefabs;
    public int selectedCharacter = 0;
    public SpriteRenderer character;

    public GameObject player;
    
    // player ID
    //public string playerId = Guid.NewGuid().ToString();

    public string playerId; 

    Vector3 spawn = new Vector3(0, 0, 0);


    // retrieve all the info related to the chosen characters from the CharacterSelectionScript
    private void Awake()
    {
        //LoadCharacter();
        LoadCharacterTest();
        Debug.Log("Character has been loaded");
    }

    private void Start()
    {
        playerId = "three";
        Debug.Log($"Player ID {playerId}");
        Debug.Log($"Player Manager{this}");
        GameManager.instance.InstantiatePlayer(playerId, this);

        // spawn the player
        player.transform.position = spawn;
    }

    // void LoadCharacter()
    //
    // {
    //
    //     int selectedCharacterInt = CharacterSelectionScript.Instance.selectedCharacter;
    //
    //     GameObject selectedCharacter = CharacterSelectionScript.Instance.characters[selectedCharacterInt];
    //     character = selectedCharacter;
    //     // Set all the necessary components
    //     
    //     //First set the sprite render to the chosen character sprite
    //
    //     player.GetComponent<SpriteRenderer>().sprite = character.GetComponent<SpriteRenderer>().sprite;
    //     
    //     //character.GetComponent<MovementScript>().cam = Camera.main;
    //     
    // }

    void LoadCharacterTest()
    {
        // Vector3 spawn = new Vector3(0, 0, 0);
        // Manual loading for testing only
        string assetName = "Red";
        // Load the corresponding asset from the Resources folder
        GameObject assetPrefab = Resources.Load(assetName) as GameObject;
        //character = Instantiate(assetPrefab);
        character = assetPrefab.GetComponent<SpriteRenderer>();
        SpriteRenderer chosenSprite = character;
        Debug.Log($"Chosen sprite info" +
                  $"color:{chosenSprite.color} sprite {chosenSprite.sprite} sorting order {chosenSprite.sortingOrder}");
        if (chosenSprite != null)
        {
            SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
            playerSprite.sprite = chosenSprite.sprite;
            playerSprite.color = chosenSprite.color;
            playerSprite.sortingOrder = chosenSprite.sortingOrder;
        }
        else
        {
            Debug.Log("Chosen sprite info was missing");
        }

        //player.transform.position = spawn;
    }

    
}