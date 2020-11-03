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
    string mentorName;

    void Start()
    {
        cursoContentUI = GetComponent<CursoContentUI>();
    }
    public void OnInit(DatabaseManager.CursoContentLineData data)
    {
        int character_id = Data.Instance.databaseManager.GetCursoByID(Data.Instance.userData.curso_active_id).character_id;
        if (character_id == 0)
            mentorName = "Xavier";
        else
            mentorName = "Christian";
        this.data = data;
        Init();

        if(data.character_id == 0)
            avatarName.text = mentorName;
        else
            avatarName.text = "Conejo";

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
