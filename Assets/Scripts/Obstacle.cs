using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    public ObstacleGenerator og;
    public bool stop;

    private void Start()
    {
        stop = false;
    }

    private void Update()
    {
        if(stop == false)
        {
            this.transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
            moveSpeed += Time.deltaTime / 10;
        }
            

        if (this.transform.position.z >= 13)
        {
            og.ObstacleDestroyed();
            Destroy(this.gameObject);
        }
    }
}
