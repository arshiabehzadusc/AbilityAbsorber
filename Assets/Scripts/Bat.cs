using UnityEngine;

public class Bat : MonoBehaviour
{
    public float speed = 2f;             // Adjust the speed of the enemy
    public float jitterRange = 1f;       // Adjust the range of jitter motion

    private Vector2 targetPosition;      // The target position for the next movement
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Set the initial target position
        targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        // Check if the enemy has reached the target position
        if (Vector2.Distance(transform.position, targetPosition) <= 0.1f)
        {
            // Get a new random target position
            targetPosition = GetRandomPosition();
        }

        // Move towards the target position
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        print("direction 1: " + direction);
        // Avoid walls
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, LayerMask.GetMask("Wall"));
        if (hit.collider != null)
        {
            // Calculate a new direction away from the wall
            direction = Vector2.Reflect(direction, hit.normal);
            print("direction 2: " + direction);
            targetPosition = GetRandomPosition();
        }

        rb.velocity = direction * speed;
    }

    private Vector2 GetRandomPosition()
    {
        // Generate a random position within the jitter range
        Vector2 randomOffset = Random.insideUnitCircle * jitterRange;
        return (Vector2)transform.position + randomOffset;
    }
}
