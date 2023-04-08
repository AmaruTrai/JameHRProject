using UnityEngine;

/// <summary>
/// Контроллер для обработки взаимодействия с окружающими обьектами.
/// </summary>
public class InteractionController : MonoBehaviour
{
	public bool IsInteractionAvailable { get; private set; }

	[SerializeField]
	private GameObject tip;

	private ConversationWrapper conversation;

	private void Update()
	{
		if (!IsInteractionAvailable) {
			return;
		}

		if (
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
}
