using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    float timeCheck = 0;
    float nextGenTime = 0;
    [SerializeField] GameObject[] obstaclePrefabs;

    List<GameObject> obstacles;
    int nextObjectNum = 0;
    bool obstacleStop = false;
    float moveSpeed = 2f;
    void Start()
    {
        obstacles = new List<GameObject>();
    }

    void Update()
    {
        timeCheck += Time.deltaTime;
        if(obstacleStop == false && timeCheck >= nextGenTime)
        {
            timeCheck = 0;
            nextGenTime = 0.5f + Random.Range(0, 0.8f);
            GameObject temp = Instantiate(obstaclePrefabs[nextObjectNum], new Vector3(Random.Range(-6.1f, 6.1f), Random.Range(1, 3), -20), Quaternion.identity);
            obstacles.Add(temp);
            temp.GetComponent<Obstacle>().og = this;
            temp.GetComponent<Obstacle>().moveSpeed = moveSpeed;
            nextObjectNum = Random.Range(0, obstaclePrefabs.Length);
            Debug.Log(nextObjectNum);
        }
        moveSpeed += Time.deltaTime / 10;
    }

    public void ObstacleDestroyed()
    {
        obstacles.RemoveAt(0);
    }

    public void GameEnd()
    {
        obstacleStop = true;
        foreach(GameObject obstacle in obstacles)
        {
            if (obstacle == null) continue;
            obstacle.GetComponent<Obstacle>().stop = true;
        }
    }

    public void ObstacleSlowDown()
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().slowDown = true;
        }
    }

    public void ObstacleSlowUp()
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().slowDown = false;
        }
    }
}
