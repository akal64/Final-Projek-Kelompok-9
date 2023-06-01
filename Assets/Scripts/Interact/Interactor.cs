using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [Header("Interaction Point")]
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;

    [Header("Object Collided")]
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private readonly Collider[] colliders = new Collider[5];
    [SerializeField] private int objectFound;

    [Header("Gizmos Size")]
    [SerializeField] private float xGizmos = 2.35f;
    [SerializeField] private float yGizmos = 2.35f;

    private PlayerInput playerInput;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update() {
        objectFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, 
            interactionPointRadius,
            colliders,
            interactableMask);

        if (objectFound > 0) {
            var interactableObject = colliders[0].GetComponent<Interactable>();
            if (interactableObject != null && playerInput.actions["Gameplay.Interact"].ReadValue<float>() > 0.5f) {
                interactableObject.Interact(this);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(interactionPoint.position, new Vector2(xGizmos, yGizmos));
    }
}
