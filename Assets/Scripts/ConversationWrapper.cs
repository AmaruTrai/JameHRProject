using DialogueEditor;
using UnityEngine;

public class ConversationWrapper : MonoBehaviour
{
	[SerializeField]
	private NPCConversation conversation;

	public virtual void ShowConversation()
	{
		ConversationManager.Instance.StartConversation(conversation);
	}

	public virtual bool ShouldShow()
	{
		return !ConversationManager.Instance.IsConversationActive;
	}
}
