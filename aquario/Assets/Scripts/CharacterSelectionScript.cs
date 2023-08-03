using System.Collections;
using System.Collections.Generic;
using Thirdweb;
using UnityEngine;

public class CharacterSelectionScript : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;
    
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
    
    // todo create a load game script
    

}
