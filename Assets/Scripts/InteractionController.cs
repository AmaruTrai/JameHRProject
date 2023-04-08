using UnityEngine;

/// <summary>
/// Контроллер для обработки взаимодействия с окружающими обьектами.
/// </summary>
public class InteractionController : MonoBehaviour
{
	public bool IsInteractionAvailable = false;

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

	}

	private void HideInteractionTip()
	{

	}
}
