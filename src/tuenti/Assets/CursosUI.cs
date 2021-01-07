using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursosUI : UIScrollItemsScreen
{
    public GameObject[] characters;
    public UICursoSeparator separation;

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
        List<int> cursosByLevel = Data.Instance.settings.GetCursosIdByLevel();
        int cursosByLevelID = 0;

        AddSeparation(cursosByLevelID);

        foreach (DatabaseManager.CursoData cursoData in Data.Instance.databaseManager.cursosData.all)
        {
            if (cursoData.id == 28)
                return;
            UICursoButton newButton = (UICursoButton)AddItem();
            bool forceUnBlock = false;
            
            if (id<Data.Instance.settings.levels[0].totalCursos && id < totalCursosDone+1)
                forceUnBlock = true;
           
            id++;

          

            newButton.OnInit(cursoData, forceUnBlock);

            if (cursosByLevelID <= cursosByLevel.Count-1 && id == cursosByLevel[cursosByLevelID])
            {
                cursosByLevelID++;
                AddSeparation(cursosByLevelID);             
            }         
        }
    }
    void AddSeparation(int id)
    {
        UICursoSeparator s = Instantiate(separation, container);
        s.Init(id);
    }

    public DatabaseManager.CursoData data;
    public override void OnUIButtonClicked(UIButton uiButton)
    {        
        UICursoButton button = (UICursoButton)uiButton;
        this.data = button.data;
        Data.Instance.userData.curso_active_id = button.data.id;
        characters[button.data.character_id].SetActive(true);
        GetComponent<CursoContentUI>().Init(CursoContentUI.types.CURSO);
        Close();       
    }
    public void OnDone()
    {
        Data.Instance.userData.SetNewCursoDone(Data.Instance.userData.curso_active_id);
        Data.Instance.userData.CursoDone();
        Data.Instance.tutorialManager.OnCursoDone();
        GotoGame(); // Init();
        GetComponent<VideoManager>().Close();
    }
    public void CursoReady()
    {
        if (data.video != "")
            Events.PlayVideo(data.video, OnDone);
        else
            OnDone();
    }
}
