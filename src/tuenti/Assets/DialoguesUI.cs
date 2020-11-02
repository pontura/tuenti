using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesUI : UIPanelScreen
{
    public Text avatarName;
    public Text field;
    CursoContentUI cursoContentUI;
    DatabaseManager.CursoContentLineData data;

    void Start()
    {
        cursoContentUI = GetComponent<CursoContentUI>();
    }
    public void OnInit(DatabaseManager.CursoContentLineData data)
    {
        this.data = data;
        Init();
        avatarName.text = data.character_id.ToString();
        field.text = data.text;

        panel.SetActive(true);
    }
    public void Next()
    {
        if (data.goto_id == 0)
            cursoContentUI.Next();
        else
            cursoContentUI.Goto(data.goto_id, data.correct);
    }
}
