using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField]
	[Min(0.001f)]
	private float movementSpeed = 5.0f;

	private CharacterController characterController;
	private Vector3 moveDirection;

	private void Start()
	{
		characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		MoveCharacter();
	}

	private void MoveCharacter()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		moveDirection = new Vector3(horizontalInput, 0, 0);
		moveDirection *= movementSpeed;

		characterController.Move(moveDirection * Time.deltaTime);
	}
}
