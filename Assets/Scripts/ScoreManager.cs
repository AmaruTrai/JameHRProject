using System;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	public UnityEvent<int> OnScoreChanged;
	public int Score => score;

	[SerializeField]
	[Min(1)]
	private int score = 1;

	[SerializeField]
	private Timer timer;

	[SerializeField]
	[Tooltip("Время через которое изменяется счет автоматически, в секундах.")]
	private float timePeriod;

	[SerializeField]
	[Tooltip("Количество на которое изменяется счет по таймеру.")]
	private int scoreIncrease;

	private DateTime lastUpdatedTime;

	public void Awake()
	{
		timer.OnTimeUpdated.AddListener(UpdateTimeScore);
	}

	private void Start()
	{
		lastUpdatedTime = timer.CurrentTime;
	}

	private void UpdateTimeScore(float delta)
	{
		var differense = timer.CurrentTime - lastUpdatedTime;
		if (differense.TotalSeconds > timePeriod) {
			IncreaseScore(scoreIncrease);
			lastUpdatedTime = timer.CurrentTime;
		}
	}

	public void IncreaseScore(int inscrease)
	{
		this.score = Mathf.Max(this.score + inscrease, 0);
		OnScoreChanged?.Invoke(inscrease);

		if (score == 0) {
			timer.EndGame();
		}
	}

	public void ResetScore()
	{
		int savedScore = Score;
		this.score = 0;
		OnScoreChanged?.Invoke(-savedScore);
	}
}
