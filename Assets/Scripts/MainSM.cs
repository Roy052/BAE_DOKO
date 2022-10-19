using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSM : MonoBehaviour
{
    [SerializeField] ObstacleGenerator og;
    [SerializeField] GameObject baelz;
    [SerializeField] TextMeshProUGUI gameOverText;

    bool gameEnd = false;
    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameEnd == false && baelz.transform.position.z >= 10)
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
    }
}
