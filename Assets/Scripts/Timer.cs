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

	private DateTime currentTime;
	private Text timerText;

	public bool IsTimeStopped { get; private set; }

	private void Awake()
	{
		currentTime = startTime.dateTime;
		timerText = GetComponent<Text>();
		timerText.text = currentTime.ToString("HH:mm");
		IsTimeStopped = false;
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
			GameManager.Instance.EndGame();
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
	}

	public void ContinueTime()
	{
		IsTimeStopped = false;
	}

	public void AddTime(float seconds)
	{
		currentTime = currentTime.AddSeconds(seconds);
		OnTimeUpdated?.Invoke(seconds);
		timerText.text = currentTime.ToString("HH:mm");
	}
}
