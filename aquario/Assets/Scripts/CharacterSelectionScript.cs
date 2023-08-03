using System.Collections;
using System.Collections.Generic;
using Thirdweb;
using UnityEngine;

public class CharacterSelectionScript : MonoBehaviour
{
    public static CharacterSelectionScript Instance;
    public GameObject[] characters;
    public int selectedCharacter = 0;


    private void Awake()
    {
        Debug.Log("Creating instance of CharacterSelectionScript on " + gameObject.name);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Another instance of CharacterSelectionScript found on " + gameObject.name + ". Destroying it.");
            Destroy(gameObject);
        }

        foreach (GameObject character in characters)
        {
            DontDestroyOnLoad(character);
        }
    }

    public void NextCharacter()
    {
        // make the current character prefab false
        characters[selectedCharacter].SetActive(false);
        // move onto next index
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        // make that prefab active
        characters[selectedCharacter].SetActive(true);
    }

    public void PrevCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        // move onto previous character index
        selectedCharacter--;
        // Lets infinite scroll
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }

        characters[selectedCharacter].SetActive(true);
    }
    public void DisableUnchosenCharacters()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i != selectedCharacter)
            {
                characters[i].SetActive(false);
            }
        }
    }

    
    

// todo create a load game script
}