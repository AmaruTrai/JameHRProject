using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour{

    public GameObject credits;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame() 
    {
        Application.Quit();
        print("Quitted game");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EnterCredits() 
    {
        credits.SetActive(true);
    }

    public void LeaveCredits() 
    {
        credits.SetActive(false);
    }
 }


