using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    public ObstacleGenerator og;
    public bool stop;
    Rigidbody rb;
    RaycastHit hit;

    public bool somethingHit;

    private void Start()
    {
        stop = false;
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(stop == false)
        {
            if(somethingHit == false && Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f))
            {
                somethingHit = true;
            }
                
            if(somethingHit)
                rb.velocity = new Vector3(0, 0, moveSpeed);
            else
                rb.velocity = new Vector3(0, -5, moveSpeed);
            //this.transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
            Debug.DrawRay(transform.position, Vector3.down * 10, Color.yellow);
            moveSpeed += Time.deltaTime / 10;
        }
            

        if (this.transform.position.z >= 13)
        {
            og.ObstacleDestroyed();
            Destroy(this.gameObject);
        }
    }

}
