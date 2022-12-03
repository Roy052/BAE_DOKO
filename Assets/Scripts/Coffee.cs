using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public float moveSpeed;
    public ObstacleGenerator og;
    public bool stop;

    public bool slowDown = false;
    float slowDownValue = 1;
    private void Start()
    {
        stop = false;
        og = GameObject.Find("ObstacleGenerator").GetComponent<ObstacleGenerator>();
    }

    private void Update()
    {
        if (stop == false)
        {
            if (slowDown == true)
                slowDownValue = 0.1f;
            else
                slowDownValue = 1;

            this.transform.position += new Vector3(0, 0, 1) * moveSpeed * slowDownValue * Time.deltaTime;

            moveSpeed += Time.deltaTime / 10;
        }

        if (this.transform.position.z >= 13)
        {
            og.CoffeeDestroyed();
            Destroy(this.gameObject);
        }

    }
}
