using UnityEngine;

public class InteractionController : MonoBehaviour
{
	public bool IsInteractionAvailable;

	private ConversationWrapper conversation;

	private void Awake()
	{
		IsInteractionAvailable = false;
	}

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
