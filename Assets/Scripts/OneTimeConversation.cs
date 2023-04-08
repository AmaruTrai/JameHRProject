public class OneTimeConversation : ConversationWrapper
{
	private bool IsShowed = false;

	public override void ShowConversation()
	{
		IsShowed = true;
		base.ShowConversation();
	}

	public override bool ShouldShow()
	{
		return !IsShowed && base.ShouldShow();
	}
}
