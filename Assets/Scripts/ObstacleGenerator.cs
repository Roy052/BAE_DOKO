using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    float timeCheck = 0;
    float nextGenTime = 0;
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] GameObject cheesePrefab, coffeePrefab;

    List<GameObject> obstacles;
    GameObject cheeseTemp;
    GameObject coffeeTemp;

    int nextObjectNum = 0;
    int obstacleCount = 0, cheeseCoffeeCount = 45;
    bool obstacleStop = false;
    float moveSpeed = 2f;

    //Probability
    int[] obstaclePercentage = new int[3] { 45, 90, 100 };
    int cheeseCoffeeGenMin = 4, cheeseCoffeeGenMax = 10;
    void Start()
    {
        obstacles = new List<GameObject>();
        cheeseCoffeeCount = Random.Range(cheeseCoffeeGenMin, cheeseCoffeeGenMax);
    }

    void Update()
    {
        timeCheck += Time.deltaTime;
        if(obstacleStop == false && timeCheck >= nextGenTime)
        {
            timeCheck = 0;
            nextGenTime = 0.5f + Random.Range(0, 0.8f);

            obstacleCount++;
            Debug.Log(obstacleCount);
            //Cheese Coffee Obstacle
            GameObject temp = null;
            if (obstacleCount == cheeseCoffeeCount)
            {
                if(obstacleCount % 2 == 0)
                {
                    temp = Instantiate(cheesePrefab, 
                        new Vector3(Random.Range(-6.1f, 6.1f), Random.Range(1, 3), -20), Quaternion.identity);
                    temp.GetComponent<Cheese>().moveSpeed = moveSpeed;
                    cheeseTemp = temp;
                }
                else
                {
                    temp = Instantiate(coffeePrefab,
                        new Vector3(Random.Range(-6.1f, 6.1f), Random.Range(1, 3), -20), Quaternion.identity);
                    temp.GetComponent<Coffee>().moveSpeed = moveSpeed;
                    Quaternion tempQuat = temp.transform.rotation;
                    tempQuat = Quaternion.Euler(-90, 0, 0);
                    temp.transform.rotation = tempQuat;
                    coffeeTemp = temp;
                }
                cheeseCoffeeCount = Random.Range(cheeseCoffeeGenMin, cheeseCoffeeGenMax);
                obstacleCount = 0;
            }
            else
            {
                temp = Instantiate(obstaclePrefabs[nextObjectNum], new Vector3(Random.Range(-6.1f, 6.1f), Random.Range(1, 3), -20), Quaternion.identity);
                obstacles.Add(temp);
                temp.GetComponent<Obstacle>().og = this;
                temp.GetComponent<Obstacle>().moveSpeed = moveSpeed;
                if (temp.tag == "Pad")
                {
                    Vector3 tempVector = temp.transform.position;
                    tempVector.y = -1;
                    temp.transform.position = tempVector;

                    Quaternion tempQuat = temp.transform.rotation;
                    tempQuat = Quaternion.Euler(0, 0, -50);
                    temp.transform.rotation = tempQuat;
                }
                    
            }
            int tempObstacleNum = Random.Range(0, 101);
            for(int i = 0; i < obstaclePercentage.Length; i++)
            {
                if (tempObstacleNum < obstaclePercentage[i])
                {
                    nextObjectNum = i;
                    break;
                }
            }
            
        }
        moveSpeed += Time.deltaTime / 10;
    }

    public void ObstacleDestroyed()
    {
        obstacles.RemoveAt(0);
    }

    public void CheeseDestroyed()
    {
        cheeseTemp = null;
    }

    public void CoffeeDestroyed()
    {
        coffeeTemp = null;
    }

    public void GameEnd()
    {
        obstacleStop = true;
        foreach(GameObject obstacle in obstacles)
        {
            if (obstacle == null) continue;
            obstacle.GetComponent<Obstacle>().stop = true;
        }

        if (cheeseTemp != null) cheeseTemp.GetComponent<Cheese>().stop = true;
        if (coffeeTemp != null) coffeeTemp.GetComponent<Coffee>().stop = true;
    }

    public void ObstacleSlowDown()
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().slowDown = true;
        }
        if (cheeseTemp != null) cheeseTemp.GetComponent<Cheese>().slowDown = true;
        if (coffeeTemp != null) coffeeTemp.GetComponent<Coffee>().slowDown = true;
    }

    public void ObstacleSlowUp()
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().slowDown = false;
        }
        if (cheeseTemp != null) cheeseTemp.GetComponent<Cheese>().slowDown = false;
        if (coffeeTemp != null) coffeeTemp.GetComponent<Coffee>().slowDown = false;
    }
}
