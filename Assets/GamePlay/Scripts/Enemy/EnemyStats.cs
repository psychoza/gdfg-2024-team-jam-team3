using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This abstract class defines the basic statistics and attributes for enemy characters.
// It includes health points (HP), damage, and movement speed.
// provides a template for implementing specific enemy statistics.

[RequireComponent(typeof(Collider2D))]
public abstract class EnemyStats : MonoBehaviour
{
    // all info about the enemy
    [SerializeField] protected int maxHP = 100;
    [SerializeField] protected Collider2D bodyCollider;
    [SerializeField] protected Collider2D headCollider;

    [SerializeField] protected int moveSpeed = 10;
    protected int currentHP;

    // This method initializes the enemy's current HP to the maximum HP at the start of the game.
    protected virtual void Start() 
    {
        currentHP = maxHP; // Set current HP to max HP
        if (bodyCollider == null || headCollider == null)
        {
            Debug.LogError($"Enemy {gameObject.name} missing collider information!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.otherCollider == bodyCollider)
        {
            // TODO: Hurt player?
            Debug.Log($"{gameObject.name} hit {other.gameObject.name}");
        }
        
        if (other.otherCollider == headCollider)
        {
            Collide(other);
        }
    }

    protected virtual void Collide(Collision2D other)
    {
        
    }
    
    // Other methods to manage enemy stats and behavior
    // For example: methods to take damage, die, attack, etc.
    // ...
}
