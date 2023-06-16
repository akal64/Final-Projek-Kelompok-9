using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
	[Header("Player Script")]
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private ClawMovement clawMovement;
	[SerializeField] private DroneAction droneAction;
	[SerializeField] private ClawAction clawAction;

	[Header("Player Reference")]
	[SerializeField] private GameObject playerGameObject;
	[SerializeField] private Rigidbody2D droneRigidbody2D;
	[SerializeField] private Camera mainCamera;

	private Vector3 mouseWorldPosition;
	private Vector3 mouseInputPosition;
	private PlayerInputMap _playerInputMap;

	public void Initialize () {

		// Input Map Settings
		_playerInputMap = new PlayerInputMap();
		EnableController();

		// Player Movement Subscribe
		_playerInputMap.Gameplay.PlayerMovement.performed += ctx => OnPlayerMovement(ctx);
		_playerInputMap.Gameplay.PlayerMovement.canceled += ctx => OnPlayerMovement(ctx);

		// Claw Movement Subscribe
		_playerInputMap.Gameplay.ClawMovement.performed += ctx => OnClawMovement(ctx);

		// Player Action Subscribe
		_playerInputMap.Gameplay.Interact.performed += ctx => OnInteract();
		_playerInputMap.Gameplay.PickObject.performed += ctx => OnPickObject();
		_playerInputMap.Gameplay.ThrowObject.performed += ctx => OnThrowObject();
		_playerInputMap.Gameplay.DropObject.performed += ctx => OnDropObject();
		_playerInputMap.Gameplay.ProcessTrash.performed += ctx => OnProcessTrash();


		playerMovement.SetDroneRigidbody2D(droneRigidbody2D);
		clawAction.Initialize();

	}


	private void Update () {
		ConvertMouseToWorldPosition();
		clawMovement.ReferenceCursorPosition(mouseWorldPosition);
	}


	private void OnDisable () {

		// Player Movement UnSubscribe
		_playerInputMap.Gameplay.PlayerMovement.performed -= ctx => OnPlayerMovement(ctx);
		_playerInputMap.Gameplay.PlayerMovement.canceled -= ctx => OnPlayerMovement(ctx);

		// Claw Movement UnSubscribe
		_playerInputMap.Gameplay.ClawMovement.performed -= ctx => OnClawMovement(ctx);

		// Player Action UnSubscribe
		_playerInputMap.Gameplay.Interact.performed -= ctx => OnInteract();
		_playerInputMap.Gameplay.PickObject.performed -= ctx => OnPickObject();
		_playerInputMap.Gameplay.ThrowObject.performed -= ctx => OnThrowObject();
		_playerInputMap.Gameplay.DropObject.performed -= ctx => OnDropObject();
		_playerInputMap.Gameplay.ProcessTrash.performed -= ctx => OnProcessTrash();

		// Input Map Settings
		DisableController();
	}

	private void OnPlayerMovement (InputAction.CallbackContext ctx) {
		if (ctx.performed) {

			Vector2 moveDirection = ctx.ReadValue<Vector2>();
			SetDroneMoveDirection(moveDirection);
			playerMovement.IsDroneMoving(true);

		} else if (ctx.canceled) {
			playerMovement.IsDroneMoving(false);

		}
	}

	private void OnClawMovement (InputAction.CallbackContext ctx) {

		mouseInputPosition = ctx.ReadValue<Vector2>();

		float playerX = playerGameObject.transform.position.x;
		float mouseWorldX = mouseWorldPosition.x;


		if (mouseWorldX < playerX) {

			RotatePlayerLeft();

		} else if (mouseWorldX > playerX) {

			RotatePlayerRight();
		}

	}

    private void OnInteract () {
		clawAction.OnInteract();
    }

	private void OnPickObject () {
		clawAction.OnPickObject();
    }

	private void OnThrowObject () {
		clawAction.OnThrowObject();
	}

	private void OnDropObject () {
		clawAction.OnDropObject();
	}

	private void OnProcessTrash () {
		clawAction.OnProcessTrash();
	}

	private void SetDroneMoveDirection(Vector2 direction) {
		playerMovement.SetDirection(direction);
	}

	private void RotatePlayerLeft () {
		playerGameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
	}

	private void RotatePlayerRight () {
		playerGameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
	}

	private void ConvertMouseToWorldPosition () {
		mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseInputPosition);
		mouseWorldPosition.z = 0;

	}

	public void EnableController () {
		_playerInputMap.Enable();
	}

	public void DisableController () {
		_playerInputMap.Disable();
	}

}
