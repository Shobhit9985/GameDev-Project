using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public float doubleJumpForce = 5f;
    private bool isGrounded = false;
    private bool canDoubleJump = true;
    private Rigidbody rb;
    private Vector3 startPosition; // Store the start position here

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = new Vector3(44f, 1f, -41f); // Set the start position
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || canDoubleJump)
            {
                float jumpStrength = isGrounded ? jumpForce : doubleJumpForce;
                rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);

                if (!isGrounded)
                {
                    canDoubleJump = false;
                }

                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true; // Allow jumping on any surface
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "RedZone") // Check for the RedZone trigger
        {
            // Reset the player's position to the start position
            transform.position = startPosition;
        }
    }
}
