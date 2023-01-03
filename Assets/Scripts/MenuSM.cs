using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSM : MonoBehaviour
{
    GameManager gm;
    [SerializeField] Image upgradeBlock, settingBlock;
    [SerializeField] TextMeshProUGUI cheeseAmountText;
    [SerializeField] TextMeshProUGUI[] upgradeValueTexts;
    [SerializeField] Button[] upgradeButtons;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        UpgradeOff();
        SettingOff();
    }

    private void Update()
    {
        bool isCheeseExist = (gm.GetCheeseAmount() > 0) ? true : false;
        foreach (Button btn in upgradeButtons)
        {
            btn.enabled = isCheeseExist;
        }
    }

    public void RunStart()
    {
        GameManager.RunStart();
    }

    public void UpgradeOn()
    {
        settingBlock.gameObject.SetActive(false);
        upgradeBlock.gameObject.SetActive(true);

        RefreshUpgradeData();
    }

    public void UpgradeOff()
    {
        upgradeBlock.gameObject.SetActive(false);
    }

    public void SettingOn()
    {
        upgradeBlock.gameObject.SetActive(false);
        settingBlock.gameObject.SetActive(true);
    }

    public void SettingOff()
    {
        settingBlock.gameObject.SetActive(false);
    }

    public void Upgrade(int index)
    {
        if (gm.GetCheeseAmount() < 1) return;
        gm.SetUpgrade(index, gm.GetUpgradeValue(index) + 1);
        gm.CheeseUpdate(-1);
        gm.SaveData();

        RefreshUpgradeData();
    }

    void RefreshUpgradeData()
    {
        cheeseAmountText.text = gm.GetCheeseAmount().ToString();
        Debug.Log(gm.GetCheeseAmount());

        for (int i = 0; i < upgradeValueTexts.Length; i++)
            upgradeValueTexts[i].text = gm.GetUpgradeValue(i).ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
