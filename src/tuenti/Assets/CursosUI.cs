using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursosUI : UIScrollItemsScreen
{
    void Start()
    {
        Loop();
    }
    public void GotoGame()
    {
        Data.Instance.LoadLevel("Game");
    }
    private void Loop()
    {
        if (Data.Instance.databaseManager.allLoaded)
            LoadData();
        else
            Invoke("Loop", 0.1f);
    }
    void LoadData()
    {
        Init();
        foreach (DatabaseManager.CursoData cursoData in Data.Instance.databaseManager.cursosData.all)
        {
            UICursoButton newButton = (UICursoButton)AddItem();
            newButton.OnInit(cursoData);
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {
        UICursoButton button = (UICursoButton)uiButton;
        Data.Instance.userData.curso_active_id = button.data.id;
        GetComponent<CursoContentUI>().Init(CursoContentUI.types.CURSO);
        Close();
    }
}
