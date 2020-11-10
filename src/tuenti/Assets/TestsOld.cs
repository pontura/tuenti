using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsOld : UIScrollItemsScreen
{
    public void OnInit()
    {
        Init();
        Reset();
        int id = 0;
        foreach (DatabaseManager.CursoData d in Data.Instance.databaseManager.cursosData.all)
        {
            if (id > 0)
            {
                bool forceActive = false;
                if (id < 2)
                    forceActive = true;
                UITestButton newButton = (UITestButton)AddItem();
                newButton.OnInit(d, forceActive);
            }
            id++;
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {
        UITestButton button = (UITestButton)uiButton;
        GetComponent<TestsUI>().OpenOldCurso(button.data.id);
        Close();
    }
    public void SetOff()
    {
        Data.Instance.LoadLevel("Game");
    }
}
