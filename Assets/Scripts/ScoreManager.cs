using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	public UnityEvent<int> OnScoreChanged;
	public int Score => score;

	[SerializeField]
	[Min(1)]
	private int score = 1;

	public void IncreaseScore(int inscrease)
	{
		this.score = Mathf.Max(this.score + inscrease, 0);
		OnScoreChanged?.Invoke(inscrease);
	}

	public void ResetScore()
	{
		int savedScore = Score;
		this.score = 0;
		OnScoreChanged?.Invoke(-savedScore);
	}
}
