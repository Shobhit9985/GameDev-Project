using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
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

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        transform.Translate(maximumSpeed * Time.deltaTime * movementDirection);
    
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
