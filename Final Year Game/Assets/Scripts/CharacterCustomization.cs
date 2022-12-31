using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterCustomization : MonoBehaviour
{
    public string CharacterName;
    public GameObject inputField;
    public GameObject textDisplay;

    public void EnterName()
    {
        CharacterName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = CharacterName;
        PlayerCharacter.PlayerName = CharacterName;

    }
}
