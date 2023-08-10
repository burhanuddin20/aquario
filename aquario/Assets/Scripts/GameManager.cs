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
    public Vector2 xRange;
    public Vector2 yRange;
    
    public Dictionary<string, PlayerManager> PlayerManagers = new Dictionary<string, PlayerManager>();

    public GameObject claimPrompt;

    // Called before start
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject); // which game object does this destroy
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        claimPrompt.SetActive(false);
        for (int i = 0; i < 50; i++)
        {
            SpawnFood();
        }
    }
    

    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        GameObject _food = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        _food.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.9f, 1f, 0.9f, 1f);
    }


    public void RegisterPlayer(string playerId, PlayerManager playerManager)
    {
        if (!PlayerManagers.ContainsKey(playerId))
        {
            PlayerManagers.Add(playerId,playerManager);
        }
        else
        {
            Debug.Log("Player already registered!");
        }
    }

    public PlayerManager GetPlayerManager(string playerId)
    {
        if (PlayerManagers.ContainsKey(playerId))
        {
            return PlayerManagers[playerId];
        }
        else
        {
            Debug.Log("No player wit that ID registered!");
            return null;
        }
    }
    public void InstantiatePlayer(string playerId,PlayerManager playerManager)
    {
      
        
        // Get the PlayerManager cpt
        //string playerId = Guid.NewGuid().ToString();
        
        RegisterPlayer(playerId,playerManager);
        SmoothCameraFollow cameraFollow = Camera.main.GetComponent<SmoothCameraFollow>();
        cameraFollow.SetTarget(playerManager.player);
    }
    
   

}