using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float droneSpeed = 10f;
    [SerializeField] private float velocityTransitionSpeed = 5f;

    private bool isMoving = false;
    private Vector2 direction;
    private Rigidbody2D droneRigidbody2D;

    private void FixedUpdate()
    {
        if (!isMoving)
        {
            // Gradually decrease the velocity to zero
            droneRigidbody2D.velocity = Vector2.Lerp(droneRigidbody2D.velocity, Vector2.zero, velocityTransitionSpeed * Time.fixedDeltaTime);
        }
        else
        {
            // Gradually increase the velocity towards the desired direction and speed
            Vector2 targetVelocity = direction * droneSpeed;
            droneRigidbody2D.velocity = Vector2.Lerp(droneRigidbody2D.velocity, targetVelocity, velocityTransitionSpeed * Time.fixedDeltaTime);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    public void IsDroneMoving(bool value)
    {
        isMoving = value;
    }

    public void SetDroneRigidbody2D(Rigidbody2D rigidbody2D)
    {
        this.droneRigidbody2D = rigidbody2D;
    }

    public Vector2 GetVelocity()
    {
        return droneRigidbody2D.velocity;
    }
}
