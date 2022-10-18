using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    float timeCheck = 0;
    float nextGenTime = 0;
    [SerializeField] GameObject[] obstacles;
    int nextObjectNum = 0;
    void Start()
    {
        
    }

    void Update()
    {
        timeCheck += Time.deltaTime;
        if(timeCheck >= nextGenTime)
        {
            timeCheck = 0;
            nextGenTime = 0.5f + Random.Range(0, 0.8f);
            Instantiate(obstacles[nextObjectNum], new Vector3(Random.Range(-6.1f, 6.1f), 1, -10), Quaternion.identity);
            nextObjectNum = Random.Range(0, obstacles.Length);
            Debug.Log(nextObjectNum);
        }
    }
}
