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
    public void OnInit(DatabaseManager.CursoContentLineData data, CursoContentUI.types type)
    {
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
    public override void OnUIButtonClicked(UIButton uiButton)
    {
        UICursoContentButton button = (UICursoContentButton)uiButton;
        cursoContentUI.Goto(button.data.goto_id);
    }
}