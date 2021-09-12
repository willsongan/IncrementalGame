using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public Button SkillButton;
    public Image SkillImage;
    public Text SkillText;
    public bool IsEnoughClick = false;
    public int ClickCount;
    public int ClickCountNeeded;
    public float GoldMultiplier;
    public bool IsActivated = false;
    [HideInInspector] public float SkillTimer;
    public float DefaultSkillTimer = 5f;

    private void Start()
    {
        SkillButton.onClick.AddListener(() =>
        {
            if (IsEnoughClick) ActivateSkill();
            else
            {
                GatherClickCount();
            }
        });
        SkillTimer = DefaultSkillTimer;
    }

    private void Update()
    {
        IsEnoughClick = (ClickCount == ClickCountNeeded);
        SkillImage.color = IsEnoughClick ? Color.yellow : Color.grey;
        ClickCountUI(ClickCount);
    }


    private void GatherClickCount()
    {
        ClickCount++;
    }

    public void ActivateSkill()
    {
        ClickCount = 0;
        IsActivated = true;
    }

    public void ClickCountUI(int value)
    {
        SkillText.text = $"Click Needed : { value.ToString("0") } / {ClickCountNeeded.ToString("0")}";
    }
}
