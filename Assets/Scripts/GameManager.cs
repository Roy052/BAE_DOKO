using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int cheeseAmount = 0;
    int[] upgradeArray = new int[5] { 0, 0, 0, 0, 0 };

    private void Start()
    {
        
    }

    public void CheeseUpdate(int amount)
    {
        if (cheeseAmount + amount > 0)
            cheeseAmount = cheeseAmount + amount;
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
}
