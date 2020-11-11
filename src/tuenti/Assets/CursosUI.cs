using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursosUI : UIScrollItemsScreen
{
    public GameObject[] characters;

    void Start()
    {
        Loop();
        ResetCharacters();
    }
    void ResetCharacters()
    {
        foreach (GameObject go in characters)
            go.SetActive(false);
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
    public override void Init()
    {
        ResetCharacters();
        LoadData();
    }
    void LoadData()
    {
        Reset();
        base.Init();
        int id = 0;

        int totalCursosDone = Data.Instance.userData.cursosDone.Count;
       
        foreach (DatabaseManager.CursoData cursoData in Data.Instance.databaseManager.cursosData.all)
        {
            UICursoButton newButton = (UICursoButton)AddItem();
            bool forceUnBlock = false;
            
            if (id<4 && id < totalCursosDone+1)
                forceUnBlock = true;
            newButton.OnInit(cursoData, forceUnBlock);
            id++;
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {        
        UICursoButton button = (UICursoButton)uiButton;

        if(button.data.video != "")
            Events.PlayVideo("d6Wu20mn5aw", OnDone);

        Data.Instance.userData.curso_active_id = button.data.id;
        characters[button.data.character_id].SetActive(true);
        GetComponent<CursoContentUI>().Init(CursoContentUI.types.CURSO);
        Close();
    }
    void OnDone()
    {

    }
}
