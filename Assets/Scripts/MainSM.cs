using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSM : MonoBehaviour
{
    [SerializeField] ObstacleGenerator og;
    [SerializeField] GameObject baelz;
    [SerializeField] TextMeshProUGUI gameOverText, cheeseText, distanceText;
    int cheeseAmount = 0;
    float distance = 0;

    bool gameEnd = false;

    //Coffee
    public int coffeeAmount = 0;
    [SerializeField] GameObject[] coffeeCans;

    //ResultUI
    [SerializeField] Image resultBox;
    [SerializeField] TextMeshProUGUI distanceCountText, cheeseCountText, scoreCountText;

    GameManager gm;
    public int[] upgradeArray;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        upgradeArray = new int[5];
        for(int i = 0; i < 5; i++)
            upgradeArray[i] = gm.GetUpgradeValue(i);

        ResultOff();
        gameOverText.gameObject.SetActive(false);
        cheeseText.text = 0 + "";
        CoffeeDisplay();
    }

    private void Update()
    {
        if(gameEnd == false)
        {
            distanceText.text = distance.ToString("0") + " m";
            distance += Time.deltaTime * 10;
        }

        if (gameEnd == false && (baelz.transform.position.z >= 10 || baelz.transform.position.y <= -5))
        {
            Destroy(baelz);
            GameEnd();
            Debug.Log("Game End");
        }
        
    }

    public void GameEnd()
    {
        gameEnd = true;
        og.GameEnd();
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(FadeManager.FadeIn(gameOverText, 1));
        Invoke("ResultOn", 1);
    }

    public void CheeseGain(int amount)
    {
        cheeseAmount += amount;
        cheeseText.text = cheeseAmount + "";
    }

    public void CoffeeGain(int amount)
    {
        coffeeAmount += amount;
        if (coffeeAmount > 3) coffeeAmount = 3;
        CoffeeDisplay();
    }

    public void CoffeeUse(int amount)
    {
        coffeeAmount -= amount;
        if (coffeeAmount < 0) coffeeAmount = 0;
        CoffeeDisplay();
    }

    void CoffeeDisplay()
    {
        for(int i = 0; i < 3; i++)
        {
            if (i + 1 > coffeeAmount) coffeeCans[i].SetActive(false);
            else coffeeCans[i].SetActive(true);
        }
    }

    public void ResultOn()
    {
        distanceCountText.text = distance.ToString("0");
        cheeseCountText.text = cheeseAmount.ToString();
        scoreCountText.text = ((int)distance + cheeseAmount * 100).ToString();
        resultBox.gameObject.SetActive(true);
        gm.CheeseUpdate(cheeseAmount);
        gm.SaveData();
    }

    public void ResultOff()
    {
        resultBox.gameObject.SetActive(false);
    }

    public void ToMenu()
    {
        GameManager.ToMenu();
    }

    public void Retry()
    {
        GameManager.Retry();
    }

    
}
