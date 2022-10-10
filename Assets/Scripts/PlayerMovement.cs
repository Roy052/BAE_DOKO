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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalnput = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalnput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 500 * Time.deltaTime);
    }
}
