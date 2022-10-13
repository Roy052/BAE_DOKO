using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody rb;

    private void Start()
    {
        moveSpeed = 2;
        rb = this.GetComponent<Rigidbody>();

        
    }

    private void Update()
    {
        this.transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
        if (this.transform.position.z >= 13) Destroy(this.gameObject);
    }
}
