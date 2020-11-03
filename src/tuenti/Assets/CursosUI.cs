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
        base.Init();
        ResetCharacters();
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
