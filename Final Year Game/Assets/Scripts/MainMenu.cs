using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public void CharacterCustom()
    {
        SceneManager.LoadScene("CharacterCreator");
    }
    public void QuiteGame()
    {
        Application.Quit();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Introduction()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
