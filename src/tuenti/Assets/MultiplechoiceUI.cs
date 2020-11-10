using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplechoiceUI : UIScrollItemsScreen
{
    public Text avatarName;
    public Text field;
    CursoContentUI cursoContentUI;
    bool isDone;
    CursoContentUI.types type;
    public Animator anim;
    DatabaseManager.CursoContentLineData data;

    private void Awake()
    {
        cursoContentUI = GetComponent<CursoContentUI>();
    }
    public void OnInit(DatabaseManager.CursoContentLineData data, CursoContentUI.types type)
    {
        this.data = data;
        this.type = type;
        isDone = false;
        Init();
        Reset();
        avatarName.text = data.character_id.ToString();
        field.text = data.text;
        List<DatabaseManager.MultiplechoiceData> arr;
        if(type == CursoContentUI.types.CURSO)
            arr = Data.Instance.databaseManager.GetMultiplechoiceDataByCursoID(data.id);
        else
            arr = Data.Instance.databaseManager.GetMultiplechoiceDataByVentaID(data.id);
        foreach (DatabaseManager.MultiplechoiceData d in arr)
        {
            print("__________" + d);
            UICursoContentButton newButton = (UICursoContentButton)AddItem();
            newButton.OnInit(d);
        }
    }
    UICursoContentButton button;
    public override void OnUIButtonClicked(UIButton uiButton)
    {        
        if (isDone)
            return;
        isDone = true;

        button = (UICursoContentButton)uiButton;
        if (type == CursoContentUI.types.CURSO)
            cursoContentUI.Goto(button.data.goto_id, button.data.correct);
        else
        {
            if (anim != null && data.character_id == 1)
            {
                Reset();
                if (button.data.correct>0)
                {
                    if(button.data.goto_id == 0)
                        anim.Play("happy");
                    else
                        anim.Play("neutral");
                    Events.PlaySound("ui", "btn_ok", false);                   
                }                    
                else
                {
                    Events.PlaySound("ui", "btn_bad", false);
                    anim.Play("unhappy");
                }
                Invoke("Delayed", 2);
                
            } else
                cursoContentUI.Goto(button.data.goto_id, button.data.correct);
        }
    }
    void Delayed()
    {
        if (anim != null)
            anim.Play("idle");
        cursoContentUI.Goto(button.data.goto_id, button.data.correct);
    }

}