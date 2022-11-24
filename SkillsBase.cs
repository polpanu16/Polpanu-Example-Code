using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Skills/Create New Skill")]
public class SkillsBase : ScriptableObject
{
    [SerializeField] string _name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int accuracy;
    [SerializeField] int evasion;
    [SerializeField] SkillType skillType;

    public string Name { get { return _name; } }
    public string Descriptiong { get { return description; } }
    public SkillType SkillType { get { return skillType; } }
    public int Attack { get { return attack; } }
    public int Defense { get { return defense; } }
    public int Accuracy { get { return accuracy; } }
    public int Evasion { get { return evasion; } }

}

public enum SkillType
{
    
    softAttack,
    HeavyAttack,
    ThrowAttack,
    Dodge,
    Guard,
    Counter
}

public class TypeChart
{
    //softATK > dodge,counter | heavyATK > guard,counter | throwAttack << counter
    //softATK < guard         | heavyATK < dodge         | throwAttack > dodge,guard 
    public static void GetEffective(SkillType attacker,SkillType defender,int attack,int currentHP,int accuracy)
    {
        if (attacker == SkillType.softAttack)
        {
            if (defender == SkillType.Dodge)
            {
                accuracy = 100;
            }

            if (defender == SkillType.Guard)
            {
                attack = 0;
            }
        }

        if (attacker == SkillType.HeavyAttack)
        {
            if (defender == SkillType.Dodge)
            {
                accuracy = 0;
            }

            if (defender == SkillType.Guard)
            {
                attack *= 2;
            }
        }

        if (attacker == SkillType.ThrowAttack)
        {
            if (defender == SkillType.Counter)
            {
                currentHP -= 20;
            }
        }
    }
}