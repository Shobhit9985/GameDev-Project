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
        //healthBar = GetComponent<HealthBar>();
        healthBar.SetMaxhealth(health);
    }
    //
    void Update()
    {
        MovePlayer();
        Crouching();

        // Rotate the player based on mouse input
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        transform.Rotate(0, y, 0);
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on player's current orientation
        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        movementDirection.y = 0f; // Ensure the player stays level with the ground

        characterController.Move(movementDirection * maximumSpeed * Time.deltaTime);

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
}
