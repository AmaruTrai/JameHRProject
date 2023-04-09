using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public GameObject credits;

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private GameObject loosePanel;

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
        if(StopedClock == true && stoponlyonce == true) 
		{
			loosePanel.SetActive(false);
		}
		if(StopedClock == true && stoponlyonce == false) 
		{
			pausePanel.SetActive(true);
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
		pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
 }


