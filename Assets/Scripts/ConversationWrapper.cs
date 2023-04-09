using DialogueEditor;
using UnityEngine;

/// <summary>
/// Обертка над NPCConversation из плагина на диалоги.
/// Нужна чтобы добавлять кастомную логику на события вызова диалога.
/// </summary>
public class ConversationWrapper : MonoBehaviour
{
	[SerializeField]
	private NPCConversation conversation;

	[SerializeField] MainMenu tm;
	private void Start()
	{
		tm = FindObjectOfType<MainMenu>();
	}
	public virtual void ShowConversation()
	{
		ConversationManager.Instance.StartConversation(conversation);
		tm.StopClock();
	}

	public virtual bool ShouldShow()
	{
		return !ConversationManager.Instance.IsConversationActive;
	}
}
