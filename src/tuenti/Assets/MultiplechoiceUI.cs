using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplechoiceUI : UIScrollItemsScreen
{
    public Text avatarName;
    public Text field;
    CursoContentUI cursoContentUI;

    private void Awake()
    {
        cursoContentUI = GetComponent<CursoContentUI>();
    }
    public void OnInit(DatabaseManager.CursoContentLineData data)
    {
        Init();
        Reset();
        avatarName.text = data.character_id.ToString();
        field.text = data.text;
        foreach (DatabaseManager.MultiplechoiceData d in Data.Instance.databaseManager.GetMultiplechoiceDataByCursoID(data.id))
        {
            print("__________" + d);
            UICursoContentButton newButton = (UICursoContentButton)AddItem();
            newButton.OnInit(d);
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {
        UICursoContentButton button = (UICursoContentButton)uiButton;
        cursoContentUI.Goto(button.data.goto_id);
    }
}