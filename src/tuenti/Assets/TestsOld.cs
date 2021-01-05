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
            bool forceActive = false;
            if (d.id == 28 && Data.Instance.userData.talked_to_samuel == 0)
                return;
            else if (d.id == 28 && Data.Instance.userData.talked_to_samuel == 1)
                forceActive = true;
            if (id > 0)
            {                
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
