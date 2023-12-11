using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public HealthBar healthBar;
    public float health = 100f;
    [SerializeField]
    private float maximumSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float jumpButtonGracePeriod;

    [SerializeField]
    private Transform cameraTransform;

    private CharacterController characterController;
    private float ySpeed;
   
    private bool crouch = false;
    public GameObject target;
    public GameObject lookAt;
    public float turnSpeed;


    // Start is called before the first frame update

    //for healthbar UI
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //healthBar = GetComponent<HealthBar>();
        healthBar.SetMaxhealth(health);
    }
    //
    void Update()
    {
        MovePlayer();
        Crouching();
        Jump();
        Sprint();

        // Rotate the player based on mouse input
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        transform.Rotate(0, y, 0);
    }

    void Jump()
    {
        // Check if the jump key (Space) is pressed
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            // Apply an upward force for jumping
            ySpeed = jumpSpeed;
        }

        // Apply gravity to simulate the character falling
        ySpeed += Physics.gravity.y * Time.deltaTime;

        // Apply the vertical movement to the character controller
        Vector3 verticalMovement = new Vector3(0, ySpeed, 0);
        characterController.Move(verticalMovement * Time.deltaTime);
    }

    void Sprint(){
        // Check if the left shift key is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Increase the movement speed when sprinting
            maximumSpeed = 40f/* Set your sprint speed here */;
        }
        else
        {
            // Reset the movement speed when not sprinting
            maximumSpeed = 10f/* Set your normal speed here */;
        }
    }


    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on player's current orientation
        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        movementDirection.y = 0f; // Ensure the player stays level with the ground

        //characterController.Move(movementDirection * maximumSpeed * Time.deltaTime);
        characterController.SimpleMove(movementDirection * maximumSpeed);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            // Adjust the player's position based on the ground normal
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

        // Update the health value in the HealthBar script
        healthBar.SetHealth(health);
    }

    private void Crouching()
    {
        if (Input.GetKeyDown("c"))
        {
            if (crouch == false)
            {
                lookAt.transform.position = new Vector3(lookAt.transform.position.x, lookAt.transform.position.y / 2f, lookAt.transform.position.z);
                crouch = true;

            }
            else
            {
                lookAt.transform.position = new Vector3(lookAt.transform.position.x, lookAt.transform.position.y * 2f, lookAt.transform.position.z);
                crouch = false;
            }
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coins++");
            GameManager.instance.manager.AddCoin();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.instance.PlayerDamage(10);
        }
    }
}
