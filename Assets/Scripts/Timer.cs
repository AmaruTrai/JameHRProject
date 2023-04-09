using DialogueEditor;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public DateTime CurrentTime => currentTime;

	public UnityEvent<float> OnTimeUpdated;

	[SerializeField]
	[Tooltip("Модификатор скорости времени")]
	[Min(0f)]
	private float timeSpeed = 1.0f;

	[SerializeField]
	[Tooltip("Время начал игры")]
	private UDateTime startTime;

	[SerializeField]
	[Tooltip("Время конца игры")]
	private UDateTime endTime;

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private GameObject loosePanel;

	private DateTime currentTime;
	private Text timerText;

	public bool IsTimeStopped { get; private set; }
	public bool stopOnlyOnce;

	private void Awake()
	{
		currentTime = startTime.dateTime;
		timerText = GetComponent<Text>();
		timerText.text = currentTime.ToString("HH:mm");
		IsTimeStopped = false;
		stopOnlyOnce = true;
	}

	private void Update()
	{
		if (!ShouldUpdateTime()) {
			return;
		}

		float deltaTime = Time.deltaTime * timeSpeed;
		currentTime = currentTime.AddSeconds(Time.deltaTime * timeSpeed);
		OnTimeUpdated?.Invoke(deltaTime);
		timerText.text = currentTime.ToString("HH:mm");

		if ((endTime - currentTime).TotalMilliseconds <= 0) {
			EndGame();
		}
	}

	private bool ShouldUpdateTime()
	{
		return
			!ConversationManager.Instance.IsConversationActive &&
			!IsTimeStopped;
	}

	public void StopTime()
	{
		IsTimeStopped = true;
		pausePanel.SetActive(true);
	}

	public void EndGame()
	{
		loosePanel.SetActive(true);
		IsTimeStopped = true;
		Time.timeScale = 0f;
	}

	public void ContinueTime()
	{
		IsTimeStopped = false;
		pausePanel.SetActive(false);
	}

	public void AddTime(float seconds)
	{
		currentTime.AddSeconds(seconds);
	}
}
