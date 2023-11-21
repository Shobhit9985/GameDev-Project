using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    float acceleration = 0.5f;
    float deceleration = 0.8f;
    int VelocityHash;
    int isJumpingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool isJumping = animator.GetBool(isJumpingHash);

        // Walking
        if (forwardPressed && velocity < 0.5f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        if (!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        // Running
        if (forwardPressed && runPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!runPressed && velocity > 0.5f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        // Jumping (Not Fixed)
        if (!isJumping && jumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
        }
        
        if (isJumping && !jumpPressed)
        {
            animator.SetBool(isJumpingHash, false);
        }

        animator.SetFloat(VelocityHash, velocity);
    }
}
