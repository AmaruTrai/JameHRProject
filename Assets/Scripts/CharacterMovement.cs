using DialogueEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField]
	[Min(0.001f)]
	private float movementSpeed = 5.0f;

	private Rigidbody2D rb2D;
	private InteractionController interactionController;
	private Vector2 moveDirection;

	private void Awake()
	{
		moveDirection = Vector3.zero;
		rb2D = GetComponent<Rigidbody2D>();
		interactionController = GetComponent<InteractionController>();
	}

	private void Update()
	{
		ControlUpdate();
	}

	private void FixedUpdate()
	{
		rb2D.velocity = new Vector2(moveDirection.x * movementSpeed, rb2D.velocity.y);
	}

	private void ControlUpdate()
	{
		if (ConversationManager.Instance.IsConversationActive) {
			moveDirection = Vector2.zero;
			return;
		}

		float horizontalInput = Input.GetAxis("Horizontal");
		moveDirection = new Vector2(horizontalInput, 0);
	}
}
