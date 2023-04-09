using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour{

    public GameObject credits;
    public GameObject pousemenu;
    
    public GameObject stoptext;

    public bool StopedClock;

    public bool stoponlyonce;
    [SerializeField] Timer tm;

    public GameObject timer;
    private void Start()
    {
        tm = FindObjectOfType<Timer>();

        StopedClock = false;
        stoponlyonce = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            pousemenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if(StopedClock == true && stoponlyonce == true) 
    {
        stoptext.SetActive(false);
    }
    if(StopedClock == true && stoponlyonce == false) 
    {
        stoptext.SetActive(true);
        stoponlyonce = true;
        StopedClock = false;
    }
    }

    public void StopClock() 
    {
        StopedClock = true;
        stoponlyonce = true;
    }

    public void ContinueClock() 
    {
        StopedClock = true;
        stoponlyonce = false;
    }
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
        Time.timeScale = 1f;
    }

    public void EnterCredits() 
    {
        credits.SetActive(true);
    }

    public void LeaveCredits() 
    {
        credits.SetActive(false);
    }

    public void LeavePouseMenu() 
    {
        pousemenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ContinueCLOCKGame() 
    {
        timer.SetActive(true);
        ContinueClock();
    }
 }


