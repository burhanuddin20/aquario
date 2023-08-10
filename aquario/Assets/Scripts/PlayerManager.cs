using System;
using System.Collections;
using System.Collections.Generic;
using Nethereum.Contracts.Standards.ERC20.TokenList;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerManager : MonoBehaviour
{
    //character
    public GameObject[] characterPrefabs;
    public int selectedCharacter = 0;
    public SpriteRenderer character;

    public GameObject player;

    // player ID
    //public string playerId = Guid.NewGuid().ToString();

    // TODO fix player id
    // random
    public string playerId;

    //Token info
    public GameObject token;
    Vector3 spawn = new Vector3(0, 0, 0);

    public ScoreManager scoreManager;

    // retrieve all the info related to the chosen characters from the CharacterSelectionScript
    private void Awake()
    {
        LoadCharacter();
        //LoadCharacterTest();
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
        token.GetComponent<TokenScript>().GetTokenBalance();
    }

    private void Update()
    {
        if (scoreManager.gems == 5)
        {
            player.GetComponent<MovementScript>().speed = 0f;
        }
    }

    void LoadCharacter()

    {
        int selectedCharacterInt = CharacterSelectionScript.Instance.selectedCharacter;
        GameObject chosenNFT = CharacterSelectionScript.Instance.characters[selectedCharacterInt];
        character = chosenNFT.GetComponent<SpriteRenderer>();


        Debug.Log($"Chosen sprite info" +
                  $"color:{character.color} sprite {character.sprite} sorting order {character.sortingOrder}");
        if (character != null)
        {
            SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
            playerSprite.sprite = character.sprite;
            playerSprite.color = character.color;
            playerSprite.sortingOrder = character.sortingOrder;
        }
        else
        {
            Debug.Log("Chosen sprite info was missing");
        }
    }

    // void LoadCharacterTest()
    // {
    //     // Vector3 spawn = new Vector3(0, 0, 0);
    //     // Manual loading for testing only
    //     string assetName = "Red";
    //     // Load the corresponding asset from the Resources folder
    //     GameObject assetPrefab = Resources.Load(assetName) as GameObject;
    //     //character = Instantiate(assetPrefab);
    //     character = assetPrefab.GetComponent<SpriteRenderer>();
    //     SpriteRenderer chosenSprite = character;
    //     Debug.Log($"Chosen sprite info" +
    //               $"color:{chosenSprite.color} sprite {chosenSprite.sprite} sorting order {chosenSprite.sortingOrder}");
    //     if (chosenSprite != null)
    //     {
    //         SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
    //         playerSprite.sprite = chosenSprite.sprite;
    //         playerSprite.color = chosenSprite.color;
    //         playerSprite.sortingOrder = chosenSprite.sortingOrder;
    //     }
    //     else
    //     {
    //         Debug.Log("Chosen sprite info was missing");
    //     }
    //
    //     //player.transform.position = spawn;
    // }
}