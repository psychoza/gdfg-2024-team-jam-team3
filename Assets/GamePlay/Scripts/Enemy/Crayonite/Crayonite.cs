using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class defines the behavior and attributes specific to the Crayonite enemy.
// It inherits from the EnemyStats class to include basic stats like health, damage, and speed.
public class Crayonite : EnemyStats
{
    // Reference to the CrayoniteMovement component that handles the movement logic.
    private CrayoniteMovement movement;

    protected override void Start()
    {
        // Call the base Start method to initialize basic stats.
        base.Start();

        movement = GetComponent<CrayoniteMovement>();
        if (movement == null)
        {
            Debug.LogError("CrayoniteMovement component not found!");
        }
    }

    void Update()
    {
        movement.SetSpeed(moveSpeed);
    }
}
