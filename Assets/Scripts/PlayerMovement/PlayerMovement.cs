using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float groundDrag;
    public float jumpSpeed = 5f;
    [Header("Ground Check")]

    public float playerHeight;
    public LayerMask groundMask;
    bool isGrounded;

    public Transform orientation;
    private float horizontalInput;
    private float verticalInput ;

    Vector3 moveDirection;
    Rigidbody rb;

   private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f, groundMask);
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        SpeedControl();
    }
    private void FixedUpdate()
    {
        if (PlayerBuild.isMain)
        {
            if (moveDirection == Vector3.zero )
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
            Debug.Log("Is Ground: " + isGrounded);
            
            MovePlayer();
        }
    }

    private void MovePlayer()
    {

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
    private void Jump()
    {
        rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        
    }

}
