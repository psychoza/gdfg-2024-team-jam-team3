using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed = 20f;

    private float m_horizontalMove = 0f;
    private bool m_jump = false;
    private bool m_crouch = false;

    void Update()
    {
        // get the horizontal input times the run speed to move the player on the x-axis
        m_horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // check if 'jump' button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            m_jump = true;
            Debug.Log("Jump");
        }

        // check if 'crouch' button is pressed
        if (Input.GetButtonDown("Crouch")) {
            m_crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) {
            m_crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Move the character
        controller.Move(m_horizontalMove * Time.fixedDeltaTime, m_crouch, m_jump);
        // reset the jump variable to avoid multiple jumps
        m_jump = false;
    }
}
