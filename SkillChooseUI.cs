using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChooseUI : MonoBehaviour
{
    [SerializeField] GameObject _skillChooseUI;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void openSkillChooseUI()
    {
        if (!_skillChooseUI.activeSelf)
        {
            _skillChooseUI.SetActive(true);
        }
        
    }
}
