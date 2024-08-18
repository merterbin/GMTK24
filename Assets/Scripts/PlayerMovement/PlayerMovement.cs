using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float groundDrag;
    [Header("Ground Check")]

    public float playerHeight;
    public LayerMask groundMask;
    bool isGrounded;

    public Transform orientation;
    private float horizontalInput =1.5f;
    private float verticalInput = 2f;

    Vector3 moveDirection;
    Rigidbody rb;

   private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f, groundMask);
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        SpeedControl();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 2f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -2f;
        }
        else
        {
            verticalInput = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1.5f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1.5f;
        }
        else
        {
            horizontalInput = 0;
        }
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * speed * 10f);
        //* 10f, ForceMode.Force
    }

    private void SpeedControl()
    { 
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
