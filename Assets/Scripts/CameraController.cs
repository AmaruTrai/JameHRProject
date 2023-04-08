using System.ComponentModel;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Цель за которой следует камера")]
	private Transform Target;

	[SerializeField]
	[Tooltip("Граница слева достигая которой, камера перестает двигаться.")]
	private Transform LeftBorder;

	[SerializeField]
	[Tooltip("Граница справа достигая которой, камера перестает двигаться.")]
	private Transform RightBorder;

	private void Update()
	{
		float positionError = Mathf.Abs(Target.position.x - transform.position.x);
		if (positionError <= 0.001f) {
			return;
		}

		float newPosition = Mathf.Clamp(Target.position.x, LeftBorder.position.x, RightBorder.position.x);
		transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
	}
}
