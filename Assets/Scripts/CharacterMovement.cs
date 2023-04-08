using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField]
	[Min(0.001f)]
	private float movementSpeed = 5.0f;

	private Rigidbody2D rb2D;
	private Vector3 moveDirection;

	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		moveDirection = new Vector2(horizontalInput, 0);
	}

	private void FixedUpdate()
	{
		rb2D.velocity = new Vector2(moveDirection.x * movementSpeed, rb2D.velocity.y);
	}
}
