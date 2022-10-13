using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;

    float horizontalInput, verticalnput;
    Vector3 moveDirection;
    Rigidbody rb;

    public float groundDrag;

    //Ground Check
    public float playerHeight;
    public LayerMask ground;
    public bool grounded;

    //Jump
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    public KeyCode jumpkey = KeyCode.Space;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalnput = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalnput + orientation.right * horizontalInput;

        SpeedControl();

        if(Input.GetKey(jumpkey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 500 * Time.deltaTime);
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 500 * airMultiplier * Time.deltaTime);

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
