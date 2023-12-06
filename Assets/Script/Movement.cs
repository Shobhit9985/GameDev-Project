using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private bool crouch = false;
    public GameObject lookAt;
    public GameObject target;

    private Rigidbody rb; // Use Rigidbody for 3D games

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Crouching();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
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

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("jekll");
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Weapon picked up");
                WeaponEquip(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }

    void WeaponEquip(GameObject obj)
    {
        Instantiate(obj, target.transform.position, target.transform.rotation).transform.SetParent(this.transform, true);
    }
}
