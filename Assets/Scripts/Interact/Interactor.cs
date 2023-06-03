using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [Header("Interaction Point")]
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;

    [Header("Object Collided")]
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private readonly Collider2D[] colliders = new Collider2D[5];
    [SerializeField] private int objectFound;

    [Header("Gizmos Size")]
    [SerializeField] private float xGizmos = 2.35f;
    [SerializeField] private float yGizmos = 2.35f;

    private PlayerInputMap playerInput;

    private void Awake() {
        playerInput = new PlayerInputMap();
        playerInput.Enable();
    }

    private void Update() {
        objectFound = Physics2D.OverlapCircleNonAlloc(interactionPoint.position,
            interactionPointRadius,
            colliders,
            interactableMask);


        if (objectFound > 0) {
            canvas.enabled= true;
            var interactableObject = colliders[0].GetComponent<Interactable>();
            if (interactableObject != null && playerInput.Gameplay.Interact.triggered) {
                interactableObject.Interact(this);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(interactionPoint.position, new Vector2(xGizmos, yGizmos));
    }
}
