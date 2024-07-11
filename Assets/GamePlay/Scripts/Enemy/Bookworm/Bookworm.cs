using UnityEngine;

// This class defines the behavior and attributes specific to the Bookworm enemy.
// It inherits from the EnemyStats class to include basic stats like health, damage, and speed.
public class Bookworm : EnemyStats
{
    // Reference to the BookwormMovement component that handles the movement logic.
    private BookwormMovement movement;

    protected override void Start()
    {
        // Call the base Start method to initialize basic stats.
        base.Start();

        movement = GetComponent<BookwormMovement>();
        if (movement == null)
        {
            Debug.LogError("BookwormMovement component not found!");
        }
    }

    void Update()
    {
        movement.SetSpeed(moveSpeed);
    }

    protected override void Collide(Collision2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        
        Debug.Log($"{gameObject.name} says 'Ouch, I got jumped on'");
        base.Collide(other);

        currentHP -= 50;
        if(currentHP <= 0)
            Destroy(gameObject);

    }
}
