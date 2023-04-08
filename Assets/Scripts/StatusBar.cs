using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Cчет при котором бар заполнен полностью.")]
	[Min(1)]
	private int maxScore = 1;
	[SerializeField]
	private ScoreManager manager;
	[SerializeField]
	private Text text;

	private Image image;

	private void Awake()
	{
		image = GetComponent<Image>();
		manager.OnScoreChanged.AddListener(UpdateStatusBar);
		UpdateStatusBar(0);
	}

	private void UpdateStatusBar(int increase)
	{
		image.fillAmount = Mathf.Clamp((float)manager.Score / (float)maxScore, 0.05f, 1);
		text.text = $"{manager.Score}";
	}
}
