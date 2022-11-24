using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills
{
    public SkillsBase Base { get; set;}
    public int Level { get; set; }

    public Skills(SkillsBase skillBase,int skillLevel)
    {
        Base = skillBase;
        Level = skillLevel;
    }

    public int Attack
    {
        get { return Base.Attack + Level; }
    }

    public int Defense
    {
        get { return Base.Defense + Level; }
    }

    public int Accuracy
    {
        get { return Base.Accuracy + Level; }
    }

    public int Evasion
    {
        get { return Base.Evasion + Level; }
    }
}

