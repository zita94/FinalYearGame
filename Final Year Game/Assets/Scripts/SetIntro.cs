using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetIntro : MonoBehaviour
{
    public string Intro;
    public GameObject IntroDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Intro = "Welcome " + PlayerCharacter.PlayerName + "!" +
            "\nThis is where the game introduction will be displayed.";
        IntroDisplay.GetComponent<Text>().text = Intro;


    }

}
