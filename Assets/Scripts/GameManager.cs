using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int cheeseAmount = 0;
    [SerializeField] int[] upgradeArray = new int[5] { 0, 0, 0, 0, 0 };
    private static GameManager gameManagerInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadData();
    }

    public void CheeseUpdate(int amount)
    {
        if (cheeseAmount + amount >= 0)
            cheeseAmount = cheeseAmount + amount;
    }

    public int GetCheeseAmount()
    {
        return cheeseAmount;
    }

    public int GetUpgradeValue(int index)
    {
        if (index > upgradeArray.Length) return -1;

        return upgradeArray[index];
    }

    public void SetUpgrade(int index, int num)
    {
        if (index > upgradeArray.Length || num < 0)
        {
            Debug.LogError("Upgrade Error");
            return;
        }
        upgradeArray[index] = num;
    }

    public static void Retry()
    {
        SceneManager.LoadScene("Main");
    }

    public static void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void RunStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void SaveData()
    {
        SaveDataScript.SaveIntoJson(cheeseAmount, upgradeArray);
    }

    public void LoadData()
    {
        CheeseData temp = SaveDataScript.LoadFromJson();
        if (temp == null)
        {
            SaveDataScript.CreateSaveData();
            return;
        }

        cheeseAmount = temp.cheese;
        for (int i = 0; i < 5; i++)
            upgradeArray[i] = temp.upgradeList[i];
    }
}
