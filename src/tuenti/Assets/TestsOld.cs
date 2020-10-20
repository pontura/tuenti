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
            if (d.test_score > 0)
            {
                UITestButton newButton = (UITestButton)AddItem();
                newButton.OnInit(d);
            }
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {
        UITestButton button = (UITestButton)uiButton;
        Data.Instance.userData.curso_active_id = button.data.id;
        Data.Instance.LoadLevel("Tests");
    }
}
