using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightingController : MonoBehaviour
{
    [SerializeField] GameManager GameManager;

    public bool IsPlayerAttacking { get; set; }
    public bool IsEnemyAttacking { get; set; }
    public bool turnStop { get; private set; }
    public bool _playerTurnEnd { get; private set; }
    public bool _enemyTurnEnd { get; private set; }
    public bool _isPlayerWinner { get; private set; }
    public bool _isEnemyWinner { get; private set; }

    [SerializeField] PlayerScript _PlayerScript;
    [SerializeField] EnemyScript _EnemyScript;

    [SerializeField] int finalDamage;
    [SerializeField] int finalAccuracy;
    [SerializeField] GameObject damagePopup;
    [SerializeField] TextMeshProUGUI damagePopupText;
    Vector3 textLeftPosition = new Vector3(-250, -60);
    Vector3 textRightPosition = new Vector3(240, -60);
    public bool canDodge;



    void Awake()
    {
        turnStop = true;
    }

    void Update()
    {
        if (GameManager.isFighting)
        {
            DamageTextPopUp();
            FightOver(_PlayerScript.currentHP, _EnemyScript.currentHP);
        }
        else if (turnStop)
        {
            IsPlayerWinner(_PlayerScript.currentHP, _EnemyScript.currentHP);
        }
    }
    void LateUpdate()
    {

        if (IsPlayerAttacking && !_playerTurnEnd && !turnStop)
        {
            FinalDamageCalculated(_PlayerScript.attack, _EnemyScript.defense);
            DodgeCalculated(_PlayerScript.accuracy, _EnemyScript.evasion);
            DamageTextPopUpMove(textLeftPosition);
            DealDamage(ref _EnemyScript.currentHP);
            _playerTurnEnd = true;
            _enemyTurnEnd = false;
        }

        if (IsEnemyAttacking && !_enemyTurnEnd && !turnStop)
        {
            FinalDamageCalculated(_EnemyScript.attack, _PlayerScript.defense);
            DodgeCalculated(_EnemyScript.accuracy, _PlayerScript.evasion);
            DamageTextPopUpMove(textRightPosition);
            DealDamage(ref _PlayerScript.currentHP);
            _enemyTurnEnd = true;
            _playerTurnEnd = false;
        }
    }
    private bool DodgeCalculated(int attacker, int defender)
    {
        finalAccuracy = attacker - defender;
        if (finalAccuracy <= 0)
        {
            int dodgeChance = 75; //MaxDodgeChance is 75%
            int Dodge = Random.Range(1, 100);
            if (dodgeChance > Dodge)
            {
                canDodge = true;
            }
            else
            {
                canDodge = false;
            }
        }
        else
        {
            int dodgeChance = 75 - finalAccuracy;
            int Dodge = Random.Range(1, 100);
            if (dodgeChance > Dodge)
            {
                canDodge = true;
            }
            else
            {
                canDodge = false;
            }
        }


        return canDodge;
    }

    private int FinalDamageCalculated(int attacker, int defender)
    {
        finalDamage = attacker - defender;
        if (finalDamage <= 0)
        {
            finalDamage = 1;
        }

        return finalDamage;
    }

    public void DealDamage(ref int currentHP)
    {
        if (!canDodge)
        {
            currentHP -= finalDamage;
        }

    }

    void FightOver(int fighterHP, int fighter2HP)
    {
        if (fighterHP <= 0 || fighter2HP <= 0)
        {
            turnStop = true;
        }
        else
        {
            turnStop = false;
        }
    }

    void IsPlayerWinner(int playerHP, int enemyHP)
    {
        if (enemyHP <= 0)
        {
            _isPlayerWinner = true;
        }
        if (playerHP <= 0)
        {
            _isEnemyWinner = true;
        }
    }

    void DamageTextPopUp()
    {
        damagePopup.SetActive(true);
        if (canDodge)
        {
            damagePopupText.text = $"MISS!!";
        }
        else
        {
            damagePopupText.text = $"{finalDamage} DMG!!";
        }
    }

    void DamageTextPopUpMove(Vector3 position)
    {
        damagePopup.transform.localPosition = position;
    }
}
