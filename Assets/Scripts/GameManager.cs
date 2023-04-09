using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	[SerializeField]
	private Timer timer;

	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private GameObject loosePanel;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
		}
	}

	public void Pause()
	{
		timer.StopTime();
		pausePanel.SetActive(true);
	}

	public void Continue()
	{
		timer.ContinueTime();
		pausePanel.SetActive(false);
	}

	public void EndGame()
	{
		loosePanel.SetActive(true);
		timer.StopTime();
		Time.timeScale = 0f;
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1f;
	}
}
