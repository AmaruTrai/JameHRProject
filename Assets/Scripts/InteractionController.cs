using UnityEngine;

/// <summary>
/// Контроллер для обработки взаимодействия с окружающими обьектами.
/// </summary>
public class InteractionController : MonoBehaviour
{
	public bool IsInteractionAvailable { get; private set; }

	[SerializeField]
	private GameObject tip;

	[SerializeField]
	private Timer timer;

	private ConversationWrapper conversation;

	private void Update()
	{
		if (!IsInteractionAvailable) {
			return;
		}

		if (
			!timer.IsTimeStopped &&
			conversation != null &&
			conversation.ShouldShow() &&
			Input.GetKeyDown(KeyCode.E)
		) {
			conversation.ShowConversation();
			HideInteractionTip();
		}
	}

	public void MakeInteractionAvailable(ConversationWrapper conversation)
	{
		IsInteractionAvailable = true;
		this.conversation = conversation;
		ShowInteractionTip();
	}

	public void MakeInteractionUnavailable()
	{
		IsInteractionAvailable = false;
		conversation = null;
		HideInteractionTip();
	}

	private void ShowInteractionTip()
	{
		if (conversation == null || !conversation.ShouldShow()) {
			return;
		}

		tip.SetActive(true);
	}

	private void HideInteractionTip()
	{
		tip.SetActive(false);
	}

	public void ShowConversation(ConversationWrapper conversation)
	{
		conversation.ShowConversation();
	}
}
