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

    bool grounded = false;
    public float obstacleHeight = 1;

    public bool slowDown = false;
    float slowDownValue = 1;

    private void Start()
    {
        stop = false;
        if (this.tag == "Pad")
            rb = null;
        else
            rb = this.GetComponent<Rigidbody>();
        og = GameObject.Find("ObstacleGenerator").GetComponent<ObstacleGenerator>();
    }

    private void Update()
    {
        if(stop == false)
        {
            if (slowDown == true)
                slowDownValue = 0.1f;
            else
                slowDownValue = 1;

            //Ground Check
            grounded = Physics.Raycast(transform.position, Vector3.down, obstacleHeight * 0.5f + 0.2f);

            if (rb == null) this.transform.position += new Vector3(0, 0, 1) * slowDownValue * moveSpeed * Time.deltaTime;
            else
            {
                if (grounded)
                    rb.velocity = new Vector3(0, 0, slowDownValue * moveSpeed);
                else
                    rb.velocity = new Vector3(0, -5, slowDownValue * moveSpeed);
                //this.transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
                Debug.DrawRay(transform.position, Vector3.down * 10, Color.yellow);
            }
            
            moveSpeed += Time.deltaTime / 10;
        }
            

        if (this.transform.position.z >= 13)
        {
            og.ObstacleDestroyed();
            Destroy(this.gameObject);
        }
    }

}
