using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesUI : UIPanelScreen
{
    Animator anim;
    public Text avatarName;
    public Text field;
    CursoContentUI cursoContentUI;
    DatabaseManager.CursoContentLineData data;
    string mentorName;
    CursoContentUI.types type;
    List<DatabaseManager.MultiplechoiceData> arr;

    void Start()
    {        
        cursoContentUI = GetComponent<CursoContentUI>();
    }
    public void OnInit(DatabaseManager.CursoContentLineData data, CursoContentUI.types type)
    {

        anim = GetComponent<CursoContentUI>().client.GetComponentInChildren<Animator>();

        this.type = type;
        this.data = data;
        Init();
        if (type == CursoContentUI.types.CURSO)
        {
            int character_id = Data.Instance.databaseManager.GetCursoByID(Data.Instance.userData.curso_active_id).character_id;
            if (character_id == 0)
                mentorName = "Xavier";
            else
                mentorName = "Christian";

            if (data.character_id == 0)
                avatarName.text = mentorName;
            else
                avatarName.text = "Conejo";
            field.text = data.text;
        }
        else
        {
            arr = Data.Instance.databaseManager.GetMultiplechoiceDataByVentaID(data.id);
            field.text = arr[0].text;
            if(arr[0].goto_id == 0 && arr[0].correct>0)
            {
                anim.Play("happy");
                Events.PlaySound("ui", "btn_ok", false);
            }
            else if (arr[0].goto_id == 0 && arr[0].correct == 0)
            {
                anim.Play("unhappy");
                Events.PlaySound("ui", "btn_bad", false);
            }
            else
            {
                anim.Play("neutral");
                Events.PlaySound("ui", "btn", false);
            }
        }
        panel.SetActive(true);
    }
    public void Next()
    {
        if (type == CursoContentUI.types.CURSO)
        {
            if (data.goto_id == 0)
                cursoContentUI.Next();
            else
                cursoContentUI.Goto(data.goto_id, data.correct);
        }
        else
        {
            cursoContentUI.Goto(arr[0].goto_id, arr[0].correct);            
        }
    }
}
