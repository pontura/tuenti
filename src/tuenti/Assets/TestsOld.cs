using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsOld : UIScrollItemsScreen
{
    public void OnInit()
    {
        Init();
        Reset();
        foreach (DatabaseManager.CursoData d in Data.Instance.databaseManager.cursosData.all)
        {
            UITestButton newButton = (UITestButton)AddItem();
            newButton.OnInit(d);
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {
        UITestButton button = (UITestButton)uiButton;
        GetComponent<TestsUI>().OpenOldCurso(button.data.id);
        Close();
    }
}
