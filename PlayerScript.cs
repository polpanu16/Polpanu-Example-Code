using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] HumanBase _base;
    SkillsBase _skillBase;

    public Skills Skills { get; set; }
    public Human Human { get; set; }

    [SerializeField] FightingController FightingController;
    SpriteRenderer Sprite;
    public int currentHP;
    [SerializeField] Slider hpSlider;
    public int attack { get; private set; }
    public int defense { get; private set; }
    public int accuracy { get; private set; }
    public int evasion { get; private set; }

    [SerializeField] int maxHP;
    [SerializeField] int level = 5;
    [SerializeField] CharacterSkills[] characterSkills = new CharacterSkills[6];


    void Start()
    {
        SetUpFighter();
        currentHP = maxHP;
        Sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HpSlider();
        if (!FightingController.IsPlayerAttacking)
        {
            ResetFighterStats();
            Defending();
        }
    }

    void LateUpdate()
    {
        if (FightingController.IsPlayerAttacking)
        {
            Attacking();
        }
    }

    void Attacking()
    {
        Sprite.color = new Color(0, 255, 0, 255);

    }

    void Defending()
    {
        Sprite.color = new Color(0, 0, 0, 255);
    }

    void SetUpFighter()
    {
        Human = new Human(_base, level);
        attack = Human.Attack;
        defense = Human.Defense;
        accuracy = Human.Accuracy;
        evasion = Human.Evasion;
        maxHP = Human.MaxHP;
        characterSkills = Human.Base.CharacterSkills;
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
}
