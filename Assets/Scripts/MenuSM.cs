using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSM : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void RunStart()
    {
        GameManager.RunStart();
    }

    public void UpgradeOn()
    {

    }

    public void UpgradeOff()
    {

    }

    public void SettingOn()
    {

    }

    public void SettingOff()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
