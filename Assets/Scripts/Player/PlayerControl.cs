using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
	[Header("Player Script")]
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private ClawMovement clawMovement;
	[SerializeField] private DroneAction droneAction;

	[Header("Player Reference")]
	[SerializeField] private GameObject playerGameObject;
	[SerializeField] private Rigidbody2D droneRigidbody2D;
	[SerializeField] private GameObject clawParent;
	[SerializeField] private Camera mainCamera;

	private PlayerInputMap _playerInputMap;
	private Vector2 mousePosition;

	private void Start () {
		Initialize();
	}

	public void Initialize () {

		// Input Map Settings
		_playerInputMap = new PlayerInputMap();
		_playerInputMap.Enable();

		// Player Movement Subscribe
		_playerInputMap.Gameplay.PlayerMovement.performed += ctx => OnPlayerMovement(ctx);
		_playerInputMap.Gameplay.PlayerMovement.canceled += ctx => OnPlayerMovement(ctx);

		// Claw Movement Subscribe
		_playerInputMap.Gameplay.ClawMovement.performed += ctx => OnClawMovement(ctx);
		_playerInputMap.Gameplay.ClawMovement.canceled += ctx => OnClawMovement(ctx);


		// Player Action Subscribe
		_playerInputMap.Gameplay.Interact.performed += ctx => OnInteract();
		_playerInputMap.Gameplay.PickObject.performed += ctx => OnPickObject();
		_playerInputMap.Gameplay.ThrowObject.performed += ctx => OnThrowObject();
		_playerInputMap.Gameplay.DropObject.performed += ctx => OnDropObject();
		_playerInputMap.Gameplay.ProcessTrash.performed += ctx => OnProcessTrash();

		// Game Subscribe
		_playerInputMap.Gameplay.Pause.performed += ctx => OnPause();


		playerMovement.SetDroneRigidbody2D(droneRigidbody2D);
	}


	private void Update () {
		clawMovement.ReferenceCursorPosition(mousePosition);
	}

	private void OnDisable () {

		// Input Map Settings
		_playerInputMap.Disable();

		// Player Movement UnSubscribe
		_playerInputMap.Gameplay.PlayerMovement.performed -= ctx => OnPlayerMovement(ctx);
		_playerInputMap.Gameplay.PlayerMovement.canceled -= ctx => OnPlayerMovement(ctx);

		// Claw Movement UnSubscribe
		_playerInputMap.Gameplay.ClawMovement.performed -= ctx => OnClawMovement(ctx);
		_playerInputMap.Gameplay.ClawMovement.canceled -= ctx => OnClawMovement(ctx);

		// Player Action UnSubscribe
		_playerInputMap.Gameplay.Interact.performed -= ctx => OnInteract();
		_playerInputMap.Gameplay.PickObject.performed -= ctx => OnPickObject();
		_playerInputMap.Gameplay.ThrowObject.performed -= ctx => OnThrowObject();
		_playerInputMap.Gameplay.DropObject.performed -= ctx => OnDropObject();
		_playerInputMap.Gameplay.ProcessTrash.performed -= ctx => OnProcessTrash();

		// Game UnSubscribe
		_playerInputMap.Gameplay.Pause.performed -= ctx => OnPause();
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
		// TODO Track Mouse Cursor Position
		if (ctx.performed) {

			clawMovement.SetClawMoveActiveStatus(true);
			Vector3 direction = ctx.ReadValue<Vector2>();
			direction.z = mainCamera.nearClipPlane;
			mousePosition = mainCamera.ScreenToWorldPoint(direction);

		} else if (ctx.canceled) {
			clawMovement.SetClawMoveActiveStatus(false);
		}
	}

	private void OnInteract () {
		// TODO Enable Interact UI ??
	}

	private void OnPickObject () {
		// TODO Pick Object in Collison Area
	}

	private void OnThrowObject () {
		// TODO Throw Object if we picked one
	}

	private void OnDropObject () {
		// TODO Drop Object if we picked one
	}

	private void OnProcessTrash () {
		// TODO If we pick trash == true, we can process it to get gold?
	}

	private void OnPause () {
		// TODO Pause the game
	}

	private void SetDroneMoveDirection(Vector2 direction) {
		playerMovement.SetDirection(direction);
	}
}
