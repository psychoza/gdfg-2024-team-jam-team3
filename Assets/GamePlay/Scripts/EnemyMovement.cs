using UnityEngine;

// This abstract class defines the movement behavior for enemy characters in the game.
// It handles basic movement logic, ground checking, and direction changing.
// provides a template for implementing specific enemy movement behaviors.
// for each kind of enemy, we can create a new script that inherits from this class
public abstract class EnemyMovement : MonoBehaviour
{
    protected float speed = 2f;
    public LayerMask groundLayer; // Layer mask to specify what is considered ground
    public float groundCheckRadius = 0.2f; // Radius for checking if the enemy is on the ground
    public Transform groundCheck;
    protected Vector2 movementDirection;
    protected bool isGrounded;
    protected bool m_FacingRight = true;


    public virtual void Start()
    {
        // Initialize the direction of movement
        ChangeDirection();
    }

    public virtual void Update()
    {
        Move();

        // Check if the enemy needs to be flipped based on movement direction
        if (movementDirection.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (movementDirection.x < 0 && m_FacingRight)
        {
            Flip();
        }
    }

    // Called at a fixed time interval, suitable for physics-related code
    public virtual void FixedUpdate()
    {
        CheckGrounded();

        // Change direction if there is no ground ahead
        if (!IsGroundAhead())
        {
            ChangeDirection();
        }
    }

    // Abstract methods to be implemented by specific enemy movement scripts
    protected abstract void Move();
    protected abstract void ChangeDirection();

    protected void CheckGrounded()
    {
        // Check for colliders in the ground check position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        isGrounded = false;

        // If any collider found is not the enemy itself, set isGrounded to true
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                break;
            }
        }
    }

    protected bool IsGroundAhead()
    {
        // Determine the position to check ahead of the enemy
        Vector2 position = groundCheck.position + (Vector3)movementDirection * (groundCheckRadius * 2);

        // Check for colliders in the ground check position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, groundCheckRadius, groundLayer);

        // If any collider found is not the enemy itself, return true (ground is ahead)
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    // Flips the direction the enemy is facing
    protected void Flip()
    {
        // Switch the facing direction
        m_FacingRight = !m_FacingRight;

        // Multiply the enemy's x local scale by -1 to flip its direction
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
