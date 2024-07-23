using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LorenzoAnimationScript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalkingPressed = Input.GetKey("Horizontal");
        animator.SetBool("IsWalking", isWalkingPressed);

        bool isJumpingPressed = Input.GetKey("Space");
        animator.SetBool("IsJumping", isJumpingPressed);
    }
}
