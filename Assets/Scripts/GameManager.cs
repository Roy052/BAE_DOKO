using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
