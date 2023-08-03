using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class LoadCharacter : MonoBehaviour
{
    //public GameObject[] characterPrefabs;
    public TMP_Text label;

    private void Start()
    {
        Vector3 spawn = new Vector3(0, 0, 0);

        int selectedCharacter = CharacterSelectionScript.Instance.selectedCharacter;
        
        GameObject character = CharacterSelectionScript.Instance.characters[selectedCharacter];
        if (character == null)
        {
            Debug.Log("Chosen character is null");
        }

        character.transform.position = spawn;

    }
}
