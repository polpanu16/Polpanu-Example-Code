using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human
{
    public HumanBase Base { get; set;}
    public int Level { get; set; }
    public Human(HumanBase humanBase,int humanLevel)
    {
        Base = humanBase;
        Level = humanLevel;
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

    public int MaxHP
    {
        get { return Base.MaxHP + Level; }
    }


}
