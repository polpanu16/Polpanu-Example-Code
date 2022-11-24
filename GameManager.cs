using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] FightingController FightingController;
    [SerializeField] UIController UIController;
    public bool isFighting { get; private set; }
    [SerializeField] GameObject fightButton;
    [SerializeField] GameObject resetButton;

    public bool playerWin { get; private set; }
    public bool enemyWin { get; private set; }
    void Start()
    {
        
    }

    void Update()
    {
        IsFighting();
        if (isFighting)
        {
            TurnControl();
        }
        else
        {
            DeclareWinner();
        }
    }

    void IsFighting()
    {
        if (FightingController.turnStop || UIController.timer <= 0)
        {
            isFighting = false;
        }
        else
        {
            isFighting = true;
        }
    }
    public void Fight()
    {
        isFighting = true;
        resetButton.SetActive(true);
        fightButton.SetActive(false);
    }

    public void ResetFight()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void TurnControl()
    {
        if ((int)UIController.timer % 2 == 0)
        {
            FightingController.IsPlayerAttacking = true;
            FightingController.IsEnemyAttacking = false;
        }
        else
        {
            FightingController.IsPlayerAttacking = false;
            FightingController.IsEnemyAttacking = true;
        }
    }

    void DeclareWinner()
    {
        playerWin = FightingController._isPlayerWinner;
        enemyWin = FightingController._isEnemyWinner;
    }
}
