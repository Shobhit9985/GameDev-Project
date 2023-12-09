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


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //healthBar = GetComponent<HealthBar>();
        healthBar.SetMaxhealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Crouching();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = cameraTransform.forward * verticalInput + cameraTransform.right * horizontalInput;
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
