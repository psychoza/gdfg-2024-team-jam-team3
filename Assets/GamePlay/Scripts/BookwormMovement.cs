using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class defines the movement behavior for the BookwormMovement enemy.
// It inherits from the EnemyMovement class to utilize basic movement logic and direction handling.
public class BookwormMovement : EnemyMovement
{
    protected override void ChangeDirection()
    {
        movementDirection.x = -movementDirection.x;
    }

    protected override void Move()
    {
        if (movementDirection == Vector2.zero)
            movementDirection = Vector2.right; 
            
        transform.Translate(speed * Time.deltaTime * movementDirection);
    }
}
