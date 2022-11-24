using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] GameManager GameManager;

    private bool isFightOver;
    public float timer;
    [SerializeField] GameObject declareWinnerUI;
    [SerializeField] GameObject skillTextUI1, skillTextUI2;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI declareWinText;

    void Start()
    {
        timer = 30;
    }
    void Update()
    {
        TimerControl();
        FightIsOver();
        SkillTextControl();
        PlayerWinner();
        EnemyWinner();
    }
    private void EnemyWinner()
    {
        if (isFightOver && GameManager.enemyWin)
        {
            declareWinText.text = "Enemy\nWins!";
        }
    }

    private void PlayerWinner()
    {
        if (isFightOver && GameManager.playerWin)
        {
            declareWinText.text = "Player\nWins!";
        }
    }

    private void TimerControl()
    {
        timerText.text = timer.ToString("F0");
        if (GameManager.isFighting)
        {
            if (timer > 0)
            {
                timer -= 1 * Time.deltaTime;
            }
            else
            {
                timer = 0;
            }
        }
    }

    void FightIsOver()
    {
        if (GameManager.playerWin || GameManager.enemyWin)
        {
            isFightOver = true;
            declareWinnerUI.SetActive(true);
        }
    }

    void SkillTextControl()
    {
        if (GameManager.isFighting)
        {
            skillTextUI1.SetActive(true);
            skillTextUI2.SetActive(true);
        }
        if (isFightOver) 
        {
            skillTextUI1.SetActive(false);
            skillTextUI2.SetActive(false);
        }
        
    }
}
