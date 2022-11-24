using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Human", menuName = "Human/Create New Human")]
public class HumanBase : ScriptableObject
{
    [SerializeField] string _name;

    [TextArea]
    [SerializeField] string description;
    [SerializeField] Sprite sprite;

    //Base Stats
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int accuracy;
    [SerializeField] int evasion;
    [SerializeField] int maxHP = 100;
    [SerializeField] CharacterSkills[] characterSkills = new CharacterSkills[6];

    public string NAME { get { return _name; } }
    public string Description { get { return description; } }
    public Sprite Sprite { get { return sprite; } }
    public int Attack { get { return attack; } }
    public int Defense { get { return defense; } }
    public int Accuracy { get { return accuracy; } }
    public int Evasion { get { return evasion; } }
    public int MaxHP { get { return maxHP; } }
    public CharacterSkills[] CharacterSkills { get { return characterSkills; } }
}

[System.Serializable]
public class CharacterSkills
{
    [SerializeField] SkillsBase skillBase;
    public SkillsBase Base
    {
        get { return skillBase; }
    }
}
