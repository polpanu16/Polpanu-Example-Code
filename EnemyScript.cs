using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] HumanBase _base;
    [SerializeField] SkillsBase _skillBase;

    public Skills Skills { get; set; }
    public Human Human { get; set; }

    [SerializeField] FightingController FightingController;
    SpriteRenderer Sprite;
    public int currentHP;
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI SkillText;
    public int attack { get; private set; }
    public int defense { get; private set; }
    public int accuracy { get; private set; }
    public int evasion { get; private set; }
    
    [SerializeField] int maxHP;
    [SerializeField] int level = 5;
    [SerializeField] CharacterSkills[] characterSkills = new CharacterSkills[6];
    [SerializeField] List<CharacterSkills> _attackTypeSkill = new List<CharacterSkills>();
    [SerializeField] List<CharacterSkills> _defenseTypeSkill = new List<CharacterSkills>();

    bool endAttackingTurn;
    bool endDefendingTurn;



    void Start()
    {
        SetUpFighter();
        currentHP = maxHP;
        Sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HpSlider();
        if (!FightingController.IsEnemyAttacking)
        {
            ResetFighterStats();
            Defending();
        }
    }

    void LateUpdate()
    {
        if (FightingController.IsEnemyAttacking)
        {
            Attacking();
        }
    }

    void Attacking()
    { 
        if (!endAttackingTurn)
        {
            Sprite.color = new Color(255, 0, 0, 255);
            RandomSkillAttack();
            endAttackingTurn = true;
            endDefendingTurn = false;
        }
    }

    void Defending()
    {
        if (!endDefendingTurn)
        {
            Sprite.color = new Color(0, 0, 0, 255);
            RandomSkillDefense();
            endAttackingTurn = false;
            endDefendingTurn = true;
        }
    }

    void SetUpFighter()
    {
        Human = new Human(_base, level);
        Skills = new Skills(_skillBase, level);
        attack = Human.Attack;
        defense = Human.Defense;
        accuracy = Human.Accuracy;
        evasion = Human.Evasion;
        maxHP = Human.MaxHP;
        characterSkills = Human.Base.CharacterSkills;

        foreach (CharacterSkills a in characterSkills)
        {
            if (a.Base.SkillType == SkillType.softAttack || a.Base.SkillType == SkillType.HeavyAttack || a.Base.SkillType == SkillType.ThrowAttack)
            {
                _attackTypeSkill.Add(a);
            }

            else
            {
                _defenseTypeSkill.Add(a);
            }
        }
    }

    void ResetFighterStats()
    {
        attack = Human.Attack;
        defense = Human.Defense;
        accuracy = Human.Accuracy;
        evasion = Human.Evasion;
        maxHP = Human.MaxHP;
    }
    void HpSlider()
    {
        hpSlider.value = currentHP;
        hpSlider.maxValue = maxHP;
    }

    void RandomSkillAttack()
    {
        int random = UnityEngine.Random.Range(0, _attackTypeSkill.Count);
        string skillName = _attackTypeSkill[random].Base.Name;
        SkillText.text = $"{skillName}";
    }

    void RandomSkillDefense()
    {
        int random = UnityEngine.Random.Range(0, _defenseTypeSkill.Count);
        string skillName = _defenseTypeSkill[random].Base.Name;
        SkillText.text = $"{skillName}";
    }
}
