﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITriviaButton : UIButton
{
    public Text field;
    public DatabaseManager.AnswerData data;
    public bool isOn;
    public Image background;

    public void OnInit(DatabaseManager.AnswerData data)
    {
        this.data = data;
        field.text = data.text;
        SetToggle();
    }
    public void Toggle()
    {
        isOn = !isOn;
        SetToggle();
    }
    public void SetOff()
    {
        isOn = false;
        SetToggle();
    }
    public void SetToggle()
    {
        if (isOn)
            background.color = Color.yellow;
        else
            background.color = Color.white;
    }
}
