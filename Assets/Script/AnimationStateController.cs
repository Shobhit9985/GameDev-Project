using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    float verticalVelocity = 0.0f;
    float horizontalVelocity = 0.0f;
    float acceleration = 0.8f;
    float deceleration = 0.8f;
    int VerticalHash;
    int HorizontalHash;
    int JumpHash;
    int CrouchHash;
    int GunHash;
    bool crouch = false;
    public bool gun = false;
    public GameObject gunObject;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VerticalHash = Animator.StringToHash("Vertical");
        HorizontalHash = Animator.StringToHash("Horizontal");
        JumpHash = Animator.StringToHash("Jump");
        CrouchHash = Animator.StringToHash("Crouch");
        GunHash = Animator.StringToHash("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool backwardPressed = Input.GetKey("s");
        bool rightPressed = Input.GetKey("d");
        bool leftPressed = Input.GetKey("a");
        // bool jumpPressed = animator.GetBool(JumpHash);

        WalkingForward(forwardPressed);
        Running(forwardPressed, runPressed);
        WalkingBackward(backwardPressed);
        RightStrafe(rightPressed);
        LeftStrafe(leftPressed);
        Crouching();
        Gun();
        Attack();

        animator.SetFloat(VerticalHash, verticalVelocity);
        animator.SetFloat(HorizontalHash, horizontalVelocity);
        // animator.SetBool(JumpHash, jumpPressed);

    }

    private void WalkingForward(bool forwardPressed)
    {
        if (forwardPressed && verticalVelocity < 1.0f)
        {
            verticalVelocity = 1.0f;
        }

        if (!forwardPressed && verticalVelocity > 0.0f)
        {
            verticalVelocity = 0.0f;
        }

        if (!forwardPressed && verticalVelocity < 0.0f)
        {
            verticalVelocity = 0.0f;
        }
       
    }

    private void Running(bool forwardPressed, bool runPressed)
    {
        if (forwardPressed && runPressed && verticalVelocity < 2.0f)
        {
            verticalVelocity += Time.deltaTime * acceleration;
        }

        if (!runPressed && verticalVelocity > 0.1f)
        {
            verticalVelocity -= Time.deltaTime * deceleration;
        }

       
    }

    private void WalkingBackward(bool backwardPressed)
    {
        if (backwardPressed && verticalVelocity >= 0.0f)
        {
            verticalVelocity = -1.0f;
        }

        if (!backwardPressed && verticalVelocity < 0.0f)
        {
            verticalVelocity = 0.0f;
        }
        
    }

    private void RightStrafe(bool rightPressed)
    {
        if (rightPressed && horizontalVelocity < 1.0f)
        {
            horizontalVelocity = 1.0f;
        }
        if (!rightPressed && horizontalVelocity > 0.0f)
        {
            horizontalVelocity = 0.0f;
        }
    }

    private void LeftStrafe(bool leftPressed)
    {
        if (leftPressed && horizontalVelocity >= 0.0f)
        {
            horizontalVelocity = -1.0f;
        }
        if (!leftPressed && horizontalVelocity < 0.0f)
        {
            horizontalVelocity = 0.0f;
        }
    }

    private void Crouching()
    {
        if (Input.GetKeyDown("c"))
        {
            if (crouch == true)
            {
                crouch = false;
                animator.SetBool(CrouchHash, false);
            }
            else
            {
                crouch = true;
                animator.SetBool(CrouchHash, true);
            }
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void Gun()
    {
        if (Input.GetKeyDown("g"))
        {
            if (gun == true)
            {
                gunObject.SetActive(false);
                gun = false;
                animator.SetBool(GunHash, false);
            }
            else
            { 
                gunObject.SetActive(true);
                gun = true;
                animator.SetBool(GunHash, true);
            }
        }
    }
}
