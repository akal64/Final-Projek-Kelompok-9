using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField] private float speed = 10f;

	private void Update () {
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

		transform.localPosition += movement * Time.deltaTime * speed;
	}
}
