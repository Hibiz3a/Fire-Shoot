using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gm_GameController : MonoBehaviour
{
    float currentScore = 0;

    [SerializeField]
    private TextMeshProUGUI text;


    [SerializeField]
    private GameObject[] objectToStart;
    [SerializeField]
    private GameObject[] objectToStop;

    private void Start()
    {
        currentScore = 0;
        UpdateScoreUi();
    }

    public void AddScore(float amount)
    {
        currentScore += amount;
        UpdateScoreUi();
    }

    private void UpdateScoreUi()
    {
        text.text = currentScore.ToString("0");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        for (int i = 0; i < objectToStart.Length; i++)
        {
            objectToStart[i].SetActive(true);
        }
        for (int i = 0; i < objectToStop.Length; i++)
        {
            objectToStop[i].SetActive(false);
        }
    }
}
