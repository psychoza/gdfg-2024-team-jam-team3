using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This abstract class defines the basic statistics and attributes for enemy characters.
// It includes health points (HP), damage, and movement speed.
// provides a template for implementing specific enemy statistics.

public abstract class EnemyStats : MonoBehaviour
{
    // all info about the enemy
    [SerializeField] protected int maxHP = 100;

    [SerializeField] protected int moveSpeed = 10;
    protected int currentHP;

    // This method initializes the enemy's current HP to the maximum HP at the start of the game.
    protected virtual void Start() 
    {
        currentHP = maxHP; // Set current HP to max HP
    }

    // Other methods to manage enemy stats and behavior
    // For example: methods to take damage, die, attack, etc.
    // ...
}
